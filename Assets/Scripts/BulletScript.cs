using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    //public static List<GameObject> bulletList;
    public float bulletSpeed = 9.0f;
    public float bulletDamage = 5.0f;

    public Camera playerView;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Collided" + collision.transform.name);
    //    if(collision.transform.name.ToLower().Contains("boss"))
    //    {
    //        Debug.Log("hit");

    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other + "2");
        Debug.Log(other.tag);
        if (other.tag == "enemy")
        {
            Debug.Log("hit");
            BossScript.health -= bulletDamage;
            Debug.Log("new boss health" + BossScript.health);
        }

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
        
        if (Vector3.Distance(transform.position, playerView.transform.position) > 25.0f && transform.name != "OGBullet")
        {
            Debug.Log("destroyed " + this.name);
            GameObject.Destroy(GameObject.Find(transform.name))
                ;
        }
            //for (int i = 0; i < bulletList.Count; i++)
        //{
        //    bulletList[i].transform.position += bulletList[i].transform.forward * bulletSpeed * Time.time;
        //}
    }
}
