using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienCollision : MonoBehaviour
{
    public bool damaged = false;
    public HealthBarScript healthBarScript;

    // Update is called once per frame
    void Update()
    {
        //Checks the hp and destroys object if hp is 0
        if (healthBarScript.hp == 0)
        {
            Destroy(gameObject);
        }
    }

    //OnTriggerEnter2D checks for objects that act as triggers collides
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        //Checks if the collision object has a tag "Projectile"
        if(collision.gameObject.tag == "Projectile")
        {
            Debug.Log("Alien spaceship got hit");
            //Updates the Sprite and the hp
            healthBarScript.updateSprite();
            healthBarScript.hp -= 50;
        }
    }

}
