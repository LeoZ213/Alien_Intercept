using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject Player;
    public GameObject shield;
    public GameObject explosion;

    public PlayerController Controller;
    public FiringMechanicScript fireMech;
    public GameplayAudio gameplayAudio;

    public float slowDelay = 2.0f;
    public bool hasRevival = false;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("alien_bullet"))
    && !shield.activeSelf)
        //Checks if the object is an Enemy, enemy's bullets, and if the shield is down
        {
            Controller.enabled = false; //Disables player movement
            Controller.rb.Sleep(); //Disables player rigidbody
            fireMech.enabled = false; //Disables firing

            if (hasRevival == true)
            {
                //Makes the spaceship immune to everything then allows it to make again
                StartCoroutine(StartRevivalAnimation(1));
            }else
            {
                //Starts the explosion and restart delay
                StartCoroutine(Explosion(2f));
            }
        }
        if (collision.gameObject.CompareTag("Negative_Effects"))
        {
            Debug.Log("Set slowness");
            StartCoroutine(DelayedSlow(2.0f));
        }

        
    }
    private IEnumerator DelayedSlow(float delay)
    {
        //Make the player slow down
        Controller.setSlowed(true);
        yield return new WaitForSeconds(delay);
        
        Controller.setSlowed(false);
        Debug.Log("Returned to normal speed");
    }

    //Used when the player gets hit and the explosion effects shows
    private IEnumerator Explosion(float delay)
    {
        gameplayAudio.PlayExplosionSound();
        gameObject.transform.Find("Explosion").gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        FindObjectOfType<GameManager>().EndGame();
    }

    //When the player has the revival power-up, the animation shows the player not losing
    private IEnumerator StartRevivalAnimation(float duration)
    {
        //Gets the Animator component from the player and enables the animation
        Animator animator = Player.GetComponent<Animator>();
        if (animator != null)
        {
            animator.enabled = true;
        }

        //Disables the animation after a duration
        yield return new WaitForSeconds(duration);
        animator.enabled = false;

        //Re-enable the components to help the player play again
        Controller.enabled = true; 
        Controller.rb.WakeUp(); 
        fireMech.enabled = true;

        //Removes the revival power-up after being used
        hasRevival = false;
    }
    
}
