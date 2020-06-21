using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float movementSpeed = 6.0f;

    public float shotTime;
    public static string bulletName = "bullet";

    public float shotDelay = 0.4f;

    public GameObject[] bulletPrefabs;

    enum bulletType
    {
        Fire=0, Water, Earth
    }

    int typesLength = (int)System.Enum.GetNames(typeof(bulletType)).Length;

    bulletType curBulletType = bulletType.Fire;
    
    public float time;

    int counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        shotTime = Time.time;
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

    // Update is called once per frame
    void Update()
    {
        time = Time.deltaTime;

        movement();
        quitGame();



        //Debug.Log("shot time: " + shotTime);
        //Debug.Log("Time.time: " + Time.time) ;

        if (Input.GetMouseButton(0))
        {
            if (Time.time - shotTime > shotDelay)
            {
                shotTime = Time.time;
                //GameObject currentBullet;
                //string type = curBulletType.ToString();
                //string fullName = "OG" + type + "Bullet";
                Instantiate(bulletPrefabs[(int)curBulletType], Camera.main.transform.position,
                    Camera.main.transform.rotation);
                //newBullet.transform.name = bulletName + counter;
                //Renderer rend = newBullet.GetComponent<Renderer>();
                //rend.material = 
                //Debug.Log("searching for " + fullName);
                //currentBullet = GameObject.Instantiate<GameObject>(GameObject.Find(fullName));
                //currentBullet.transform.rotation = Camera.main.transform.rotation;
                //currentBullet.transform.position = Camera.main.transform.position;
                //currentBullet.transform.name = bulletName + counter;
                counter++;
                //BulletScript.bulletList.Add(currentBullet);

                //Debug.Log("spawned bullet");

            }

        }
        int scrollAmount = (int)Input.mouseScrollDelta.y;
        if (scrollAmount != 0)
        {

            curBulletType = (bulletType)(((int)curBulletType + (int)(Input.mouseScrollDelta.y)) % typesLength);
            if ((int)curBulletType == -1)
                curBulletType = (bulletType)(typesLength - 1);
            //Debug.Log("switched to " + curBulletType.ToString() + "Bullet");

        }
        if (Input.GetMouseButtonDown(1))
        {

            Cursor.visible = !Cursor.visible;
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;

        }

    }
}
