using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float moveSpeed = 7.0f;
    public Rigidbody2D rb;
    public float damage = 50;

    private void Update()
    {
        Destroy(gameObject, 2.0f);
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        //Checks if it's the enemy and destroys the projectile (itself)
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy hit!");
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, moveSpeed); //moves in the y direction
    }
}
