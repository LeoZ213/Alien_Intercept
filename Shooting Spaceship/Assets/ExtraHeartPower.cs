using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraHeartPower : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerCollision playerCollision;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -1);

        playerCollision = GameObject.FindObjectOfType<PlayerCollision>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCollision.hasRevival = true;
            Debug.Log("Set hasRevival to true");
            Destroy(gameObject);
        }
    }
}
