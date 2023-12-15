using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirtSplashMovement : MonoBehaviour, IPooledObject
{
    public Rigidbody2D rb;
    public float velocity;
    public GameObject prefab;

    public void OnObjectSpawn()
    {
        //Gets a random float from the range of 0.5f to 2f for the SplashArea call
        float delay = Random.Range(0.5f, 2f);

        //Sets the velocity of the rigidbody
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, velocity);

        //Calls the SplashArea after the value "delay"
        Invoke("SplashArea", delay);
    }

    //Creates a green splash to slow player down at the position of the projectile
    public void SplashArea()
    {
        GameObject greenSplash = Instantiate(prefab,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
    }
}
