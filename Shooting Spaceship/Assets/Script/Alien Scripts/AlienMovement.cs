using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    [SerializeField]
    private float screenBorder = 30;

    public float moveSpeed = 1.0f;
    public Rigidbody2D rb;
    public float maxVariability = 4.0f;
    public float minVariability = -4.0f;

    private Camera camera1;

    private void Start()
    {
        camera1 = Camera.main;

        // Generate a random variability within the specified range
        float variability = Random.Range(minVariability, maxVariability);

        // Set the velocity based on variability
        rb.velocity = new Vector2(variability, 0) * moveSpeed;
    }
    private void FixedUpdate()
    {
        reverseVelocity();
    }

    /*
     * Checks if the Alien is near the border
     * Changes the direction to the opposite way if the Alien hits the border
     */
    private void reverseVelocity()
    {
        Vector2 screenPosition = camera1.WorldToScreenPoint(rb.position);
        if ((screenPosition.x < screenBorder) || (screenPosition.x > camera1.pixelWidth - screenBorder))
        {
            //Makes the alien move the other way by 0.01 when it touches the border
            if (rb.position.x < 0)
            {
                rb.position = new Vector2(rb.position.x + 0.01f, rb.position.y);
            }else
            {
                rb.position = new Vector2(rb.position.x - 0.01f, rb.position.y);
            }            

            //Reverses the direction
            rb.velocity = new Vector2(-rb.velocity.x, 0);
            
        }
    }
}
