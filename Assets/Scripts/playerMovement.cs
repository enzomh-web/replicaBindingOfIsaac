using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    
    [Header("Movimentação")]
    public float moveSpeed = 5f;
    Vector2 movement;
    public float friction = 0.8f;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (movement != Vector2.zero) 
            rb.linearVelocity = movement * moveSpeed;
        else 
            rb.linearVelocity *= friction;
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    public void OnFire(InputValue value)
    {

    }
}