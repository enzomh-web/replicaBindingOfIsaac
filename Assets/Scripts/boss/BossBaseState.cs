using UnityEngine;

public abstract class BossBaseState : MonoBehaviour
{
    public abstract void EnterState();

    public abstract void UpdateState();
    
    public abstract void OnCollisionEnter();
    
    public abstract void OnTriggerEnter();

}
