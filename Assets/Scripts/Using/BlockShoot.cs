using UnityEngine;
using System.Collections;

public class BlockShoot : MonoBehaviour
{
    public GameObject bullet;
    public float shootDelay = 0.3f;
    private bool canShoot = true;
    public string shootKey = "Shoot";

    void FixedUpdate()
    {
        tryToShoot();
    }

    void tryToShoot()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.right * 10f);

        //Angle between mouse and this object
        float angle = AngleBetweenPoints(transform.position, mouseWorldPosition);
        if (canShoot && Input.GetKey(KeyCode.Mouse0))
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0f, 0f, angle + 90f)));
            canShoot = false;
            Invoke("ResetShot", shootDelay);
        }
    }

    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void ResetShot()
    {
        canShoot = true;
    }


}