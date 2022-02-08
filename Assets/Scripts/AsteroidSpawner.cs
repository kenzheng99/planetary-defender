using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AsteroidSpawner : MonoBehaviour {
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private float spawnTimeMean = 5f;
    [SerializeField] private float spawnTimeVar = 1f;
    [SerializeField] private float spawnRadius = 30f;
    [SerializeField] private float forceMean = 1f;
    [SerializeField] private float forceVar = 0.5f;
    [SerializeField] private float forceAnglePerturbation = 10f;
    [SerializeField] private float torqueMean = 0.1f;
    [SerializeField] private float torqueVar = 0.05f;
    
    private float nextSpawnTime = 0;

    void Update() {
        // if time to spawn,
        if (Time.time > nextSpawnTime) {
            
            // pick position on unit circle according to spawnRadius
            Vector2 normalizedSpawnPosition = Random.insideUnitCircle.normalized;
            
            // instantiate object
            GameObject spawned = Instantiate(objectToSpawn, normalizedSpawnPosition * spawnRadius, Quaternion.identity);
            
            // give object a starting force
            Rigidbody spawnedRb = spawned.GetComponent<Rigidbody>();
            Vector3 force = -normalizedSpawnPosition * Random.Range(forceMean - forceVar, forceMean + forceVar);
            force = Quaternion.Euler(0, 0, Random.Range(-forceAnglePerturbation, +forceAnglePerturbation)) * force;
            spawnedRb.AddForce(force, ForceMode.Impulse);
            
            
            // give object a starting torque 
            Vector3 torque = new Vector3(
                Random.Range(torqueMean - torqueVar, torqueMean + torqueVar),
                Random.Range(torqueMean - torqueVar, torqueMean + torqueVar),
                Random.Range(torqueMean - torqueVar, torqueMean + torqueVar)
            );
            spawnedRb.AddTorque(torque, ForceMode.Impulse);

            // sample next starting time
            float timestep = Random.Range(spawnTimeMean - spawnTimeVar, spawnTimeMean + spawnTimeVar);
            nextSpawnTime = Time.time + timestep;
        }
    }
}
