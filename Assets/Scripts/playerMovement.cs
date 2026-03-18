using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    
    [Header("Movimentação")]
    public float moveSpeed = 5f;
    float horizontalMovement;
    float verticalMovement;
    bool isMoving = false; 
    float acceleration = 0.4f;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (verticalMovement == 0 && horizontalMovement == 0)
        {
            isMoving = false;
        }

        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, verticalMovement * moveSpeed);
        
        if (isMoving = false)
        { 
            Debug.Log("parado");
            rb.linearVelocity = rb.linearVelocity * acceleration;
        }
    }

    public void OnMove(InputValue value)
    {
        horizontalMovement = value.Get<Vector2>().x;
        verticalMovement = value.Get<Vector2>().y;
    }

}
