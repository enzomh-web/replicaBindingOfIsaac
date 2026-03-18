using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    
    [Header("Movimentação")]
    public float moveSpeed = 5f;
    float horizontalMovement;
    float verticalMovement;

    void Start()
    {
        
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, verticalMovement * moveSpeed);
    }

    public void OnMove(InputValue value)
    {
        Debug.Log("receba");
        horizontalMovement = value.Get<Vector2>().x;
        verticalMovement = value.Get<Vector2>().y;
    }

}
