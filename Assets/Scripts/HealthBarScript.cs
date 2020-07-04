using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Code by Colter B (Goldenlion5648)
public class HealthBarScript : MonoBehaviour
{

    public Image healthBarForeground, healtBarBackground;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void healthBarPositioning(float health, float startingHealth)
    {
        var foreground = healthBarForeground.rectTransform;
        var back = healtBarBackground.rectTransform;
        //Debug.Log("width " + back.rect.width);
        //Debug.Log("width " + back.rect.width * back.transform.localScale.x);

        //foreground.sizeDelta = new Vector2(back.rect.width * back.transform.localScale.x *
        //    (health / startingHealth), foreground.sizeDelta.y);
        //Debug.Log(back.rect.width);

        foreground.sizeDelta = new Vector2(back.rect.width *
            (health / startingHealth), foreground.sizeDelta.y);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
