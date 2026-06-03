using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Transform player;

    [Header("Segments")]
    public List<Transform> segments = new List<Transform>();
    
    [Header("SegmentsDistance")]
    public float distancebetween = 0.5f;

    [Header("Velocity")]
    public float movespeed = 5f;

    private List<Vector3> positionhistory = new List<Vector3>();

    void Start()
    {
        positionhistory.Add(transform.position);
    }

    
    void Update()
    {
        MoveHead();
        MoveSegments();
    }

    void MoveHead()
    {
    Vector3 dir = (player.position - transform.position).normalized;

    transform.position += dir * movespeed * Time.deltaTime;

    positionhistory.Insert(0, transform.position);
    }
    void MoveSegments()
    {
        for(int i = 0; i < segments.Count; i++)
        {
            int index = Mathf.RoundToInt(i * distancebetween * 10);
            
            if (index < positionhistory.Count)
            {
                Vector3 point = positionhistory[index];

                Transform segment = segments[i];

                segment.position = Vector3.Lerp(segment.position,point,Time.deltaTime * 15f);

                Vector3 direction = point - segment.position;

                if (direction != Vector3.zero)

                {
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                    segment.rotation = Quaternion.Euler(0, 0, angle);
                }
            }
        }

        if (positionhistory.Count > 1000)
        {
            positionhistory.RemoveAt(positionhistory.Count - 1);
        }
    }
}
