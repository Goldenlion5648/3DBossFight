using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
//Code by Colter B (Goldenlion5648)
public class PlayerControls : Entity
{
    public float movementSpeed = 10.0f;

    public float shotTime;
    public static string bulletName = "bullet";

    public float shotDelay = 0.4f;

    public Image healthBarForeground, healtBarBackground;

    public GameObject[] bulletPrefabs;


    public enum bulletType
    {
        Fire = 0, Water, Earth
    }

    Dictionary<bulletType, float> bulletDamageMap = new Dictionary<bulletType, float>();


    int typesLength = (int)System.Enum.GetNames(typeof(bulletType)).Length;

    public bulletType curBulletType = bulletType.Fire;

    public float time;

    int counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        shotTime = Time.time;
        health = startingHealth;

        this.Initialize(100, 14f);

        foreach (bulletType b in Enum.GetValues(typeof(bulletType)))
        {
            bulletDamageMap.Add(b, 3.0f);

        }


    }

    void healthBarPositioning()
    {
        var foreground = healthBarForeground.rectTransform;
        var back = healtBarBackground.rectTransform;
        foreground.sizeDelta = new Vector2(back.sizeDelta.x * (health / startingHealth), foreground.sizeDelta.y);

    }

    void quitGame()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.F5))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }

    void movement()
    {
        Vector3 pos = transform.position;


        if (Input.GetKey(KeyCode.W))
        {
            //pos -= Vector3. (Camera.main.transform.forward, new Vector3(1,0,1)) * movementSpeed * time;
            pos += new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z) * movementSpeed * time;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos -= new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z) * movementSpeed * time;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos -= Camera.main.transform.right * movementSpeed * time;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos += Camera.main.transform.right * movementSpeed * time;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            pos.y += movementSpeed * time / 2;
        }
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    pos.y -= movementSpeed * time / 2;
        //}
        transform.position = pos;

        //Debug.Log("Camera: " + Camera.main.transform.forward);
        //Debug.Log("Pos: " + pos);
    }

    void changeBulletType()
    {
        int scrollAmount = (int)Input.mouseScrollDelta.y;
        if (scrollAmount != 0)
        {

            curBulletType = (bulletType)(((int)curBulletType + (int)(Input.mouseScrollDelta.y)) % typesLength);
            if ((int)curBulletType == -1)
                curBulletType = (bulletType)(typesLength - 1);
            //Debug.Log("switched to " + curBulletType.ToString() + "Bullet");

        }
    }

    void fireBullet()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time - shotTime > shotDelay)
            {
                shotTime = Time.time;

                var newBullet = Instantiate(bulletPrefabs[(int)curBulletType], Camera.main.transform.position,
                    Camera.main.transform.rotation);

                newBullet.GetComponent<BulletScript>().bulletDamage = bulletDamageMap[curBulletType];
                //bulletDamageMap[curBulletType] = Mathf.Max(Convert.ToSingle(Math.Pow((double)bulletDamageMap[curBulletType], .8)), .3f);
                bulletDamageMap[curBulletType] *= .75f;
                bulletDamageMap[curBulletType] = Math.Max(bulletDamageMap[curBulletType], .3f);


                counter++;
            }
        }
    }

    void relockToScreen()
    {
        if (Input.GetMouseButtonDown(1))
        {

            Cursor.visible = !Cursor.visible;
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("touched " + other);

        if (other.gameObject != null && other.tag == "enemy")
        {
            gameObject.GetComponent<Entity>().takeDamage(other.gameObject.GetComponent<Entity>().damageOnTouch);
            Debug.Log("player took damge, new health " + health);

        }
    }
    ////void tr

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject.name);
    //    if (collision.transform.tag == "enemy")
    //    {
    //        gameObject.GetComponent<Entity>().takeDamage(collision.gameObject.GetComponent<Entity>().damageOnTouch);

    //        Debug.Log("health " + health);

    //    }
    //    //collision.collider
    //}

    void enemyDetection()
    {
        //var collider = GetComponent<Collider>();
        //bool isColliding = Physics.CheckCapsule(collider.bounds.center, new Vector3(collider.bounds.center.x,
        //    collider.bounds.center.y, collider.bounds.center.z), .3f,);

        LayerMask mask = LayerMask.GetMask("Enemy");

        var cam = Camera.main.transform;

        //Debug.Log("camera pos " + cam.position);

        //Debug.Log("transform pos " + transform.position);

        RaycastHit hit;
        bool nearEnemy = Physics.Raycast(cam.position, cam.forward, 1.0f, mask);
        if (nearEnemy)
        {
            nearEnemy = Physics.Raycast(cam.position, cam.forward, out hit);
            //Debug.Log("nearEnemy: " + nearEnemy);
            //De
            gameObject.GetComponent<Entity>().takeDamage(hit.collider.gameObject.GetComponentInParent<Entity>().damageOnTouch);
        }


        //Debug.Log("nearEnemy" + nearEnemy);

        //Debug.Log(isColliding);
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.deltaTime;

        movement();
        quitGame();

        fireBullet();
        changeBulletType();
        relockToScreen();
        //enemyDetection();


    }

}
