using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//Code by Colter B
public class BulletScript : MonoBehaviour
{

    //public static List<GameObject> bulletList;
    private float bulletSpeed = 40.0f;
    private float bulletDamage = 5.0f;

    public Camera playerView;

    public GameObject floatingTextPrefab;

    private float lastDebug;

    // Start is called before the first frame update
    void Start()
    {
        lastDebug = Time.time;
        playerView = Camera.main;
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
        //Debug.Log(other + "2");
        //Debug.Log(other.tag);

        if (!gameObject)
            return;
        if (other.tag == "enemy" && BossScript.hitCooldown == 0)
        {
            //Debug.Log("hit");
            BossScript.health -= bulletDamage;
            Debug.Log("new boss health" + BossScript.health);


            var floater = Instantiate(floatingTextPrefab, transform.position,
                Quaternion.LookRotation(Camera.main.transform.forward), other.transform);

            floater.GetComponent<TextMeshPro>().text = bulletDamage.ToString();
            //floater.GetComponent<TextMeshPro>().color.a = 
            floater.GetComponent<Rigidbody>().AddExplosionForce(80f, other.transform.position, 50);
            //floater.GetComponent<Rigidbody>().AddExplosionForce(80f, other.transform.position, 50);

            BossScript.hitCooldown = BossScript.cooldownWhenHit;
            GameObject.Destroy(gameObject);


        }
        else if (other.tag != "Player")
        {
            Debug.Log("hit solid");
            GameObject.Destroy(GameObject.Find(transform.name));
        }

    }

    // Update is called once per frame
    void Update()
    {
        //if (Time.time - lastDebug >= 1)
        //{

        //    Debug.Log("forward " + transform.forward);
        //    Debug.Log("time " + Time.deltaTime);
        //    lastDebug = Time.time;
        //}


        if (Time.time - lastDebug >= 1)
        {

            Debug.Log("forward " + transform.forward);
            Debug.Log("bulletSpeed " + bulletSpeed);
            Debug.Log("time " + Time.deltaTime);
            Debug.Log(transform.forward * bulletSpeed * Time.deltaTime * 100000);
            Debug.Log(transform.name);
            Debug.Log(transform.position);

            lastDebug = Time.time;
        }
        //Debug.Log("transform.forward " + transform.forward);
        //Debug.Log(bulletSpeed);
        //Debug.Log(Time.deltaTime);


        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
        //GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed * Time.deltaTime;
        //GetComponent<Rigidbody>().AddExplosionForce(100f, transform.position, 40f);



        if (Vector3.Distance(transform.position, playerView.transform.position) > 25.0f && transform.name.Contains("OG") == false)
        {
            //Debug.Log("destroyed " + this.name);
            GameObject.Destroy(gameObject);
        }
        //for (int i = 0; i < bulletList.Count; i++)
        //{
        //    bulletList[i].transform.position += bulletList[i].transform.forward * bulletSpeed * Time.time;
        //}
    }
}
