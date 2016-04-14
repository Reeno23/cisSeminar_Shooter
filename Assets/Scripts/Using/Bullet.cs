using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    /*
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy" && col.gameObject != null)
        {
            Destroy(col.gameObject);
        }
    }
     * */
}