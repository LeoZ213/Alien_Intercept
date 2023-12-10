using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBulletPower : MonoBehaviour
{
    public Rigidbody2D rb;
    public FiringMechanicScript fireMech;
    // Start is called before the first frame update
    void Start()
    {
        //Sets a initial downward velocity
        rb.velocity = new Vector2(0, -1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If fastbullet power-up collides with a player, decreases the time per bullet (Increased fire rate)
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(TimedIncreaseFireRate(0.125f, 3f));
        }
    }
    //Increases the firerate of the player for a specific amount of time 
    IEnumerator TimedIncreaseFireRate(float fireRate, float time)
    {
        //Takes account the original fireRate 
        float originalFireRate = fireMech.fireRate;

        //Set the new firerate 
        fireMech.fireRate = fireRate;

        //Disables the renderer component to make the powerup invisible while still being able to run the rest of the code
        gameObject.GetComponent<Renderer>().enabled = false;

        //After a certain time, you get back the original firerate
        yield return new WaitForSeconds(time);
        fireMech.fireRate = originalFireRate;

        //Destroys the gameobject
        Destroy(gameObject);
    }
}
