using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform fireSpawn;
    
    [Header("Movimentação")]
    public float moveSpeed = 5f;
    Vector2 movement;
    public float friction = 0.8f;

    [Header("Tiro")]
    public GameObject firePrefab;
    Vector2 fireDirection;
    bool isFiring;
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (movement != Vector2.zero) 
            rb.linearVelocity = movement * moveSpeed;
        else 
            rb.linearVelocity *= friction;

        if (isFiring && Time.time >= nextFireTime)
        {
            GameObject fire = Instantiate(firePrefab, fireSpawn.position, Quaternion.identity);
            fire.GetComponent<fireScript>().Initialize(fireDirection);

            nextFireTime = Time.time + fireRate;
            Debug.Log(nextFireTime);
        }
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    public void OnFire(InputValue value)
    {
        fireDirection = value.Get<Vector2>();

        if (fireDirection == Vector2.zero)
        {
            isFiring = false;
            return;
        }

        if (Mathf.Abs(fireDirection.x) > Mathf.Abs(fireDirection.y))
        {
            fireDirection = new Vector2(fireDirection.x, 0f);
        }
        else
        {
            fireDirection = new Vector2(0f, fireDirection.y);
        }

        fireDirection.Normalize();
        isFiring = true;
    }
}