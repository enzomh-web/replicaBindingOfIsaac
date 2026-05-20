using UnityEngine;

public class BossActions : MonoBehaviour
{
    public bool canExecute = true;
    public Rigidbody2D rb;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // public abstract void Execute();
}
