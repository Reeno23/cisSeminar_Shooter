using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
       {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            else if (collision.gameObject.tag == "Wall")
            {
                Destroy(gameObject);
            }
        }
    }
}