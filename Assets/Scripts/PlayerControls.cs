using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code by Colter B
public class PlayerControls : MonoBehaviour
{
    public float movementSpeed = 10.0f;

    public float shotTime;
    public static string bulletName = "bullet";

    public float shotDelay = 0.4f;

    float health;
    float maxHealth = 100;

    public GameObject[] bulletPrefabs;

    enum bulletType
    {
        Fire = 0, Water, Earth
    }

    int typesLength = (int)System.Enum.GetNames(typeof(bulletType)).Length;

    bulletType curBulletType = bulletType.Fire;

    public float time;

    int counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        shotTime = Time.time;
        health = maxHealth;
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

                Instantiate(bulletPrefabs[(int)curBulletType], Camera.main.transform.position,
                    Camera.main.transform.rotation);

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
    //void tr

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.transform.tag == "enemy")
        {
            health -= 3;
            Debug.Log("health " + health);

        }
        //collision.collider
    }

    void enemyDetection()
    {
        //var collider = GetComponent<Collider>();
        //bool isColliding = Physics.CheckCapsule(collider.bounds.center, new Vector3(collider.bounds.center.x,
        //    collider.bounds.center.y, collider.bounds.center.z), .3f,);

        LayerMask mask = LayerMask.GetMask("Enemy");

        var cam = Camera.main.transform;

        //Debug.Log("camera pos " + cam.position);

        //Debug.Log("transform pos " + transform.position);



        bool nearEnemy = Physics.Raycast(cam.position, cam.forward, 20.0f, mask);

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
        enemyDetection();


    }

}
