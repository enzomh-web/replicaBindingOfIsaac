using UnityEngine;

public class fireScript : MonoBehaviour
{
    private Vector2 _fireDirection;
    public float speed = 10f;
    public float lifeTime = 1f;


    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(_fireDirection * speed * Time.deltaTime);
    }


    public void Initialize(Vector2 direction)
    {
        _fireDirection = direction;
    }

}
