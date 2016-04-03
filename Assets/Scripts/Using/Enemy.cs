using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float speed = 3;
    public Transform protagonist;

    void FixedUpdate()
    {

            //transform.rotation = Quaternion.Slerp(transform.rotation,
                //Quaternion.LookRotation(protagonist.position - transform.position), speed * Time.deltaTime);
            //transform.rotation = Quaternion.LookRotation()
            transform.LookAt(protagonist);
            transform.position += transform.forward * speed * Time.deltaTime;
            //transform.Translate(Vector3.forward * speed);
            //transform.Translate(0, speed * Time.deltaTime, 0);

    }
}
