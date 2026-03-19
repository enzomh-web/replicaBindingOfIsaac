using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    
    [Header("Movimentação")]
    public float moveSpeed = 5f;
    float horizontalMovement;
    float verticalMovement;
    bool isMoving; 
    public float friction = 0.8f;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (isMoving == true)
        {
            rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, verticalMovement * moveSpeed);
        }
        else if (isMoving == false)
        { ;
            rb.linearVelocity = rb.linearVelocity * friction;
        }
    }

    public void OnMove(InputValue value)
    {
        horizontalMovement = value.Get<Vector2>().x;
        verticalMovement = value.Get<Vector2>().y;

        if (Mathf.Abs(horizontalMovement) < 0.01f && Mathf.Abs(verticalMovement) < 0.01f)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

}
