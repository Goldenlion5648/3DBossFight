using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float movementSpeed = 6.0f;

    public float shotTime;
    public static string bulletName = "bullet";
    
    public float time;

    int counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        shotTime = Time.time;
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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            pos.y -= movementSpeed * time / 2;
        }
        transform.position = pos;

        //Debug.Log("Camera: " + Camera.main.transform.forward);
        //Debug.Log("Pos: " + pos);
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.deltaTime;

        movement();

        //Debug.Log("shot time: " + shotTime);
        //Debug.Log("Time.time: " + Time.time) ;

        if (Input.GetMouseButton(0))
        {
            if (Time.time - shotTime > 0.4f)
            {
                shotTime = Time.time;
                GameObject currentBullet = GameObject.Instantiate<GameObject>(GameObject.Find("OGBullet"));
                currentBullet.transform.rotation = Camera.main.transform.rotation;
                currentBullet.transform.position = Camera.main.transform.position;
                currentBullet.transform.name = bulletName + counter;
                counter++;
                //BulletScript.bulletList.Add(currentBullet);

                Debug.Log("spawned bullet");

            }

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
