using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{

    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Messing with prefab's material sucks. This finally worked. Have to separate everything that you're working with from the prefab to touch it.
        Material m = new Material(enemy.GetComponent<MeshRenderer>().sharedMaterial);
        m.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
        GameObject newEnemy = enemy;

        Instantiate(newEnemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        newEnemy.GetComponent<MeshRenderer>().material = m;
    }
}
