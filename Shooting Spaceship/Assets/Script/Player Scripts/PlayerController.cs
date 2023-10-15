using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed = 4.5f;
    public InputAction playerControls;
    public bool isSlowed = false;

    Vector2 moveDirection = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable(); }

    //Moves the player based on the inputs
    private void FixedUpdate()
    {
        if (isSlowed)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed/2, moveDirection.y * moveSpeed/2);
        }
        else
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }
    public void setSlowed(bool value)
    {
        isSlowed = value;
    }
    
    

}


