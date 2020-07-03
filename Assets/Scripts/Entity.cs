using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void takeDamage(float damage)
    {
        if (hitCooldown == 0)
        {
            health -= damage;
            Debug.Log("new health" + health);
            hitCooldown = hitCooldownMax;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
