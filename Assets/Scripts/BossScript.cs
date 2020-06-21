using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{

    public static float health = 4000.0f;
    float lastJump;
    // Start is called before the first frame update
    void Start()
    {
        lastJump = 4;
    }

    void move()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastJump > 1)
        {

            lastJump += 100;
        }
    }
}
