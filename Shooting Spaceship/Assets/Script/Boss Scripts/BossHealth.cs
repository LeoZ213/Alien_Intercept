using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private int health = 300;
    public TextMeshProUGUI healthText;

     void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            health--;
            healthText.text = health.ToString();
        }
    }
}
