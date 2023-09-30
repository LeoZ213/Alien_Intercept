using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController Controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("We hit an object!");
        if (collision.gameObject.tag == "Enemy") //Checks if the object is an Enemy
        {
            Debug.Log("We hit an alien spaceship!");
            Controller.enabled = false; //Disables player movement
            Controller.rb.Sleep(); //Disables player rigidbody
            FindObjectOfType<GameManager>().EndGame(); //Ends the game
        }
    }
}
