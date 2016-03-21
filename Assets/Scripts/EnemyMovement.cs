using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 1;
    public GameObject protagonist;

    // Update is called once per frame
    void Update()
    {
        if ((protagonist.transform.position - transform.position).magnitude > 1)
        {
            transform.LookAt(protagonist.transform.position);
            transform.Translate(Vector3.forward * speed);
        }
    }
}
