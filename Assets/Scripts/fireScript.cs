using UnityEngine;

public class fireScript : MonoBehaviour
{
    public GameObject firePrefab;
    bool isFiring;
    public float fireRate = 1f;
    private float nextFireTime = 0f;
    public float speed = 10f;
    public float lifeTime = 1f;
    public Transform fireSpawn;
    
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        transform.Translate(fireDirection * speed * Time.deltaTime);

        if (isFiring && Time.time >= nextFireTime)
        {
            GameObject fire = Instantiate(firePrefab, fireSpawn.position, Quaternion.identity);
            fire.GetComponent<fireScript>().Initialize(fireDirection);

            nextFireTime = Time.time + fireRate;
            Debug.Log(nextFireTime);
        }
    }

    public void Initialize(Vector2 direction)
    {
        fireDirection = direction;
    }

    public void Fire(Vector2 fireDirection)
    {
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
