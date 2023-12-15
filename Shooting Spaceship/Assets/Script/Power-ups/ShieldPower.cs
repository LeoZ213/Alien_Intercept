using UnityEngine;

public class ShieldPower : MonoBehaviour
{
    public Rigidbody2D rb;
    
    void Start()
    {
        //Sets a initial downward velocity
        rb.velocity = new Vector2(0, -1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If shield power-up collides with a player, finds and enables the shield children on the Player
        if (collision.gameObject.tag == "Player")
        {
            Transform shield = collision.transform.Find("Shield");
            if (shield != null)
            {
                shield.gameObject.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
