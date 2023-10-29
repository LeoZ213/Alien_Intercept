using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FiringMechanicScript : MonoBehaviour
{
    public BulletMovement bullet;
    public float fireRate = 0.25f;
    private float nextFireTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate; //Updates the next allowed firing time
            BulletMovement clone = Instantiate(bullet,transform.position, transform.rotation);
        }
    }
}
