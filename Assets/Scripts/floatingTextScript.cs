using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code by Colter B
public class floatingTextScript : MonoBehaviour
{

    private float maxAliveTime = 1.5f;

    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, maxAliveTime);
        player = GameObject.Find("PlayerHead").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player, Vector3.up);
        transform.Rotate(new Vector3(0, 180, 0));
        //Debug.Log("new looking" + transform.rotation);


        //Debug.Log(-12 % 5);


    }
}
