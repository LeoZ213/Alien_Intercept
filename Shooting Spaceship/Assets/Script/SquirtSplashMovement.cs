using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirtSplashMovement : MonoBehaviour, IPooledObject
{
    public Rigidbody2D rb;
    public float velocity;

    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -3);
        Invoke("SplashArea", 2.0f);
    }
    public void SplashArea()
    {

    }
}
