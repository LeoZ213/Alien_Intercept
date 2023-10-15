using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController Controller;
    public float slowDelay = 2.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("We hit something");
        if ((collision.gameObject.tag == "Enemy") || (collision.gameObject.tag == "alien_bullet")) //Checks if the object is an Enemy
        {
            Controller.enabled = false; //Disables player movement
            Controller.rb.Sleep(); //Disables player rigidbody
            FindObjectOfType<GameManager>().EndGame(); //Ends the game
        }
        if (collision.gameObject.tag == "Negative_Effects")
        {
            Debug.Log("Set slowness");
            StartCoroutine(DelayedSlow(2.0f));
        }
    }
    private IEnumerator DelayedSlow(float delay)
    {
        //Make the player slow down
        Controller.setSlowed(true);
        yield return new WaitForSeconds(delay);
        
        Controller.setSlowed(false);
        Debug.Log("Returned to normal speed");
    }
}
