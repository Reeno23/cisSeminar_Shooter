using UnityEngine;
using System.Collections;

public class BlockShoot : MonoBehaviour
{

    public GameObject bullet;
    public float shootDelay = 0.1f;
    private bool canShoot = true;
    public string shootKey = "Shoot";

    void ResetShot()
    {
        canShoot = true;
    }

    // Update is called once per frame
  /*  void Update()
    {

        // Mouse Position in the world. It's important to give it some distance from the camera. 
        //If the screen point is calculated right from the exact position of the camera, then it will
        //just return the exact same position as the camera, which is no good.
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

        //Angle between mouse and this object
        float angle = AngleBetweenPoints(transform.position, mouseWorldPosition);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }*/

    void FixedUpdate()
    {
        //Vector3 shootDirection = Vector3.right * Input.GetAxis("Horizontal")
        //   + Vector3.up * Input.GetAxis("Vertical");
        if (canShoot && Input.GetKey(KeyCode.Mouse0))
        {
        //    transform.rotation = Quaternion.LookRotation(shootDirection, Vector3.up);
            Instantiate(bullet, transform.position, transform.rotation);
            canShoot = false;
            Invoke("ResetShot", shootDelay);
        }
    }

    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }


}
/* Weirdly faces middle of screen
 Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);
        //
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position); */
/*        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 100))
        {
            Vector3 hitPoint = hit.point;
            Vector3 targetDir = hitPoint - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
*/
/*if (Input.GetKeyDown(KeyCode.W))
            transform.forward = new Vector3(0f, 1f, 0f);
        else if (Input.GetKeyDown(KeyCode.S))
            transform.forward = new Vector3(0f, -1f, 0f);
        else if (Input.GetKeyDown(KeyCode.A))
            transform.forward = new Vector3(1f, 0f, 0f);
        else if (Input.GetKeyDown(KeyCode.D))
            transform.forward = new Vector3(-1f, 0f, 0f);*/

/*	void Update () {
Vector3 shootDirection = Vector3.right * Input.GetAxis("Horizontal")
   + Vector3.up * Input.GetAxis("Vertical");
        if(canShoot && shootDirection.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(shootDirection, Vector3.up);
            Instantiate(bullet, transform.position, transform.rotation);
canShoot = false;
            Invoke("ResetShot", shootDelay);
        }
    }*/
/*Vector3 mouseScreen = Input.mousePosition;
Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg - 90);*/