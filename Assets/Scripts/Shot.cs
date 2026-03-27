using UnityEngine;
using UnityEngine.InputSystem;

public class Shot : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Tiro")]
    public bool visibility = true;
    public float moveSpeed = 15f;



    void Start()
    {

    }

    void Update()
    {
        GetComponent<SpriteRenderer>().enabled = visibility;
    }

    public void OnFire(InputValue value)
    {
        rb.linearVelocity = new Vector2(playerMovement.horizontalMovement * moveSpeed, playerMovement.verticalMovement * moveSpeed);
    }
}
