using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienCollision : MonoBehaviour
{
    public bool damaged = false;
    public HealthBarScript healthBarScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBarScript.getHeatlh() == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.gameObject.tag == "Projectile")
        {
            damaged = true;
            //TODO Code the healthbar so it changes when it gets hit
        }
    }

}
