using UnityEngine;
using System.Collections;

public class WallBehavior : MonoBehaviour 
{
    // Destroy bullet if it hits a wall.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
    }

}
