using UnityEngine;
using System.Collections;

public class BlockMovement : MonoBehaviour {

    public float speed = 1;
	
	// Update is called once per frame
    // Normalized time keeps the object from moving at different speeds when moving at diagonal directions
	void Update () {
        transform.position += (Vector3.right * Input.GetAxis("Horizontal")
            + Vector3.up * Input.GetAxis("Vertical")).normalized * Time.deltaTime * speed;
	}
}
