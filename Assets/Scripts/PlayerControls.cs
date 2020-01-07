using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float movementSpeed = 6.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float time = Time.deltaTime;
        Vector3 pos = transform.position;


        if (Input.GetKey(KeyCode.W))
        {
            pos -= Vector3.Cross(Camera.main.transform.forward, new Vector3(1,0,1)) * movementSpeed * time;
        }

        if (Input.GetKey(KeyCode.S))
        {
            pos -= pos += Vector3.Cross(Camera.main.transform.forward, Vector3.up);
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos -=Camera.main.transform.right * movementSpeed * time;

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

        Debug.Log("Camera: " + Camera.main.transform.forward);
        Debug.Log("Pos: " + pos);




    }
}
