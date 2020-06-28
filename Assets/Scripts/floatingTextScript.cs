using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code by Colter B
public class floatingTextScript : MonoBehaviour
{

    private float maxAliveTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, maxAliveTime);
    }

    // Update is called once per frame
    void Update()
    {


    }
}
