using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBulletMovement : MonoBehaviour, IPooledObject
{
    public float velocity;
    public Rigidbody2D rb;
    

    //Everytime the alien bullet gets reused, sets a downard velocity
    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -3);
    }
}
