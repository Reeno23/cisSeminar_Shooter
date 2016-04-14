using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 1;
    public GameObject protagonist;

    void FixedUpdate()
    {
        if ((protagonist.transform.position - transform.position).magnitude > 1)
        {
            transform.LookAt(protagonist.transform.position);
            transform.Translate(Vector3.forward * speed);
        }
    }
}
