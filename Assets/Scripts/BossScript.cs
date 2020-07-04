﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Code by Colter B (Goldenlion5648)
public class BossScript : Entity
{

    //public static float startingHealth = 4000.0f;
    //public static float health = 4000.0f;
    //public static int hitCooldown = 0;
    //public static int cooldownWhenHit = 3;
    float lastJump;
    // Start is called before the first frame update
    //float rotateSpeed = .2f;
    float spinTimer = 0f;
    float spinFrequency = .5f;
    float spinAmount = 2f;



    public UnityEvent bossHit;
    void Start()
    {
        lastJump = 4;
        //InvokeRepeating("rotate", .5f, .02f);

        InvokeRepeating("cooldownUpdater", 0, .1f);
        this.Initialize(100, 3f);
        this.damageOnTouch = 30.0f;



        //this.ini


    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "bullet")
    //    {
    //        this.takeDamage(5);
    //        Debug.Log("New Boss health" + this.health);
    //        Destroy(collision.gameObject);
    //    }
    //}

    //public void takeDamage(float damageToTake)
    //{
    //    health -= damageToTake;
    //    //Debug.Log("new boss health" + BossScript.health);


    //    hitCooldown = cooldownWhenHit;
    //}

    //void cooldownUpdater()
    //{
    //    hitCooldown = Mathf.Max(hitCooldown - 1, 0);
    //}

    void rotate()
    {

        transform.Rotate(new Vector3(0f, spinAmount, 0f), Space.World);
        if (Time.time - spinTimer > spinFrequency)
        {

            spinTimer = Time.time;
            spinFrequency = Mathf.Max(spinFrequency - .6f, .25f);
            spinAmount = Mathf.Min(spinAmount + .4f, 7f);
            //spinAmount += .2f;
        }

    }

    void moveTowardPlayer(bool isAirAttack)
    {
        var power = isAirAttack ? 3 : 7;
        GetComponent<Rigidbody>().AddForce((new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z) -
                new Vector3(transform.position.x, 0, transform.position.z)) * power);
    }

    // Update is called once per frame
    void Update()
    {
        //rotate();
        if (Input.GetKey(KeyCode.C))
        {
            rotate();

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            moveTowardPlayer(false);

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
            //Debug.Log(explosionPos);

            GetComponent<Rigidbody>().AddExplosionForce(100f, explosionPos, 40f);
            moveTowardPlayer(true);

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
