using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController Controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("We got hit!");
        if ((collision.gameObject.tag == "Enemy") || (collision.gameObject.tag == "alien_bullet" )) //Checks if the object is an Enemy
        {
            Controller.enabled = false; //Disables player movement
            Controller.rb.Sleep(); //Disables player rigidbody
            FindObjectOfType<GameManager>().EndGame(); //Ends the game
        }
    }
}
