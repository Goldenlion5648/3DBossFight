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
        var bossPos = GameObject.Find("BossBody").transform.position;
        var camPos = transform.position;

        Camera.main.transform.forward = new Vector3(bossPos.x - camPos.x, bossPos.y - camPos.y, bossPos.z - camPos.z);
        yaw = transform.eulerAngles.x;
        pitch = transform.eulerAngles.y;

        //for (int i = 0; i < Mathf.Pow(SceneScript.cubeDim, 3); i++)
        //{
        //    MeshRenderer mesh = GameObject.Find(SceneScript.textPartName + i).GetComponent<MeshRenderer>();
        //    mesh.enabled = !mesh.enabled;
        //}
        //Cursor.visible = false;
    }

    public float speedH = 3.0f;
    public float speedV = 4.0f;

    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked && Cursor.visible == false)
        {
            //yaw = transform.eulerAngles.x;
            //pitch = transform.eulerAngles.y;
            yaw += speedH * Input.GetAxis("Mouse X");
            //if (pitch - speedV * Input.GetAxis("Mouse Y") > -90 && pitch - speedV * Input.GetAxis("Mouse Y") < 90)
            //Debug.Log("pitch " + pitch);

            //if (pitch < 0 && pitch + speedV * Input.GetAxis("Mouse Y") < 0)
            //    pitch += speedV * Input.GetAxis("Mouse Y");

            //if (pitch > 180 && pitch + speedV * Input.GetAxis("Mouse Y") > 180)
            pitch += speedV * Input.GetAxis("Mouse Y");
            pitch = pitch % 360;
            pitch = Mathf.Max(pitch, 90);
            pitch = Mathf.Min(pitch, 270);

            //Debug.Log("after pitch " + pitch);

            transform.eulerAngles = new Vector3(pitch, yaw, 180.0f);

        }


    }

}
