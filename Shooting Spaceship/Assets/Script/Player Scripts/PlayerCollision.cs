using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController Controller;
    public float slowDelay = 2.0f;
    public GameObject shield;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("alien_bullet"))
    && !shield.activeSelf)
        //Checks if the object is an Enemy, enemy's bullets, and if the shield is down
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
