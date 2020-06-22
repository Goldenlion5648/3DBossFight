using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{

    public static float health = 4000.0f;
    float lastJump;
    // Start is called before the first frame update
    float rotateSpeed = .2f;
    float spinTimer = 0f;
    float spinFrequency = .5f;
    float spinAmount = 2f;
    void Start()
    {
        lastJump = 4;
        //InvokeRepeating("rotate", .5f, .02f);
    }

    void move()
    {

    }

    void rotate()
    {
        transform.Rotate(new Vector3(0f, spinAmount, 0f), Space.World);


    }


    // Update is called once per frame
    void Update()
    {
        //rotate();
        if (Input.GetKey(KeyCode.C))
        {
            rotate();
            if (Time.time - spinTimer > spinFrequency)
            {

                spinTimer = Time.time;
                spinFrequency -= .1f;
                //spinAmount += .2f;
            }
        }


        //if (Time.time - lastJump > 1)
        if (Input.GetKeyDown(KeyCode.T))
        {
            var camPos = Camera.main.transform.position;
            var horPos = transform.position - new Vector3(camPos.x > transform.position.x ? .5f : -.5f,
                transform.position.y, camPos.z > transform.position.x ? .5f : -.5f);
            //var horPos = transform.position - new Vector3((camPos.x - transform.positio/*n*/.x) / 10, transform.position.y, (camPos.z - transform.position.x) / 10);

            //horPos.x = horPos.x < 0 ? -1 : 1;

            //horPos.z = horPos.z < 0 ? -1 : 1;
            //horPos /= 2;
            horPos.y -= 1f;
            //var explosionPos = transform.position + horPos;
            var explosionPos = transform.position - new Vector3(0, 1, 0);
            Debug.Log(explosionPos);

            GetComponent<Rigidbody>().AddExplosionForce(100f, explosionPos, 40f);
            GetComponent<Rigidbody>().AddForce((new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z) -
                new Vector3(transform.position.x, 0, transform.position.z)) * 3);
            //transform.position +=
            //    (new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z) -
            //    new Vector3(transform.position.x, 0, transform.position.z)) / 10;
            //GetComponent<Rigidbody>().AddExplosionForce(150f, Vector3.MoveTowards(
            //    new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z),
            //    new Vector3(transform.position.x, 0, transform.position.z), 20f), 40f);
            //GetComponent<Rigidbody>().AddExplosionForce(300f, explosionPos, 40f);
            lastJump += 100;
        }
    }
}
