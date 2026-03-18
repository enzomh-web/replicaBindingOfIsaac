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
    float acceleration = 0.1f;


    void Start()
    {
        
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, verticalMovement * moveSpeed);
        if (isMoving = false)
        { 
            rb.linearVelocity = rb.linearVelocity * acceleration;
        }
    }

    public void OnMove(InputValue value)
    {
        isMoving = true;
        Debug.Log("receba");
        horizontalMovement = value.Get<Vector2>().x;
        verticalMovement = value.Get<Vector2>().y;

        if (value.Get<Vector2>() == 0, 0)
        {
            isMoving = false;
        }
    }

}
