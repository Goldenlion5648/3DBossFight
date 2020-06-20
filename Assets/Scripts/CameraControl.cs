using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    private float yaw;
    private float pitch;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yaw = Camera.main.transform.eulerAngles.y;
        pitch = Camera.main.transform.eulerAngles.x;

        //for (int i = 0; i < Mathf.Pow(SceneScript.cubeDim, 3); i++)
        //{
        //    MeshRenderer mesh = GameObject.Find(SceneScript.textPartName + i).GetComponent<MeshRenderer>();
        //    mesh.enabled = !mesh.enabled;
        //}
        //Cursor.visible = false;
    }


    public float speedH = 2.5f;
    public float speedV = 2.5f;




    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            if (pitch - speedV * Input.GetAxis("Mouse Y") > -90 && pitch - speedV * Input.GetAxis("Mouse Y") < 90)
                pitch -= speedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }





    }


}
