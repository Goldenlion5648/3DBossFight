﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code by Colter B (Goldenlion5648)
public class Entity : MonoBehaviour
{
    //private float maxHealth;
    //private float health;
    //private float hitCooldownMax;
    //private float hitCooldown;
    public float startingHealth { get; set; }
    public float health { get; set; }
    public float hitCooldownMax { get; set; }
    public float hitCooldown { get; set; }

    public float damageOnTouch { get; set; }



    public void Initialize(float maxHealth, float hitCooldownMax)
    {
        this.startingHealth = maxHealth;
        this.health = this.startingHealth;
        this.hitCooldownMax = hitCooldownMax;
        InvokeRepeating("cooldownUpdater", 0, .1f);

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void cooldownUpdater()
    {
        hitCooldown = Mathf.Max(hitCooldown - 1, 0);
    }



    public bool takeDamage(float damage)
    {
        if (hitCooldown == 0)
        {
            health -= damage;
            Debug.Log("new health" + health);
            hitCooldown = hitCooldownMax;

            Debug.Log("new health " + health);


            //Debug.Log("damaged object " + gameObject);

            if (gameObject.GetComponent<HealthBarScript>() != null)
                gameObject.GetComponent<HealthBarScript>().healthBarPositioning(health, startingHealth);

            return true;

        }
        return false;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
