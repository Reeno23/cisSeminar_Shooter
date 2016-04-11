using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

    GameObject player;

    /*void FixedUpdate()
    {
        OnCollisionEnter();
    }*/

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (collision.gameObject.tag == "Player")
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
