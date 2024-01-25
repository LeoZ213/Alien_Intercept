using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    //Pixel width distance from the border
    [SerializeField]
    private float screenBorder = 50;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "xBorder")
        {
            rb.velocity = new Vector2(-rb.velocity.x, 0);
        }
    }
}