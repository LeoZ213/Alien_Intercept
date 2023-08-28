using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float moveSpeed = 6.0f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
