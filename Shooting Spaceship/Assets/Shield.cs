using System.Runtime.CompilerServices;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public ObjectPooler objectPooler;
    public Collider2D player;
    private void Start()
    {
        objectPooler = FindObjectOfType<ObjectPooler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //Checks if objectPooler has been assigned, if not logs a warning and exits the method
        if (objectPooler == null)
        {
            Debug.LogWarning("ObjectPooler is not assigned to Shield script.");
            return;
        }

        //Checks if shield collides with an alien projectile
        if (collision.gameObject.CompareTag("alien_bullet"))
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);

            if (collision.gameObject.name == "Alien bullet" || collision.gameObject.name == "Alien bullet(Clone)")
            {
                // TODO NEED TO FIX PLAYER HORIZONTALLY MOVING COLLIDING WITH SHIELD BUT STILL GAME OVER
                player.enabled = false;
                objectPooler.poolDictionary["NormalBullet"].Enqueue(collision.gameObject);
                player.enabled = true;
            }
        }
    }
}
