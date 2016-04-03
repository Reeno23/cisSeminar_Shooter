using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (collision.gameObject.tag == "Enemy")
            {

                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}