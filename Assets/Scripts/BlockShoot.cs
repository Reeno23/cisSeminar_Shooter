using UnityEngine;
using System.Collections;

public class BlockShoot : MonoBehaviour {

    public GameObject bullet;
    public float shootDelay = 0.1f;
    private bool canShoot = true;
    public string shootKey = "Shoot";

	void ResetShot()
    {
        canShoot = true;	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 shootDirection = Vector3.right * Input.GetAxis("Horizontal")
           + Vector3.up * Input.GetAxis("Vertical");

        if(canShoot && shootDirection.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(shootDirection, Vector3.up);
            Instantiate(bullet, transform.position, transform.rotation);

            canShoot = false;
            Invoke("ResetShot", shootDelay);
        }

    }
}
