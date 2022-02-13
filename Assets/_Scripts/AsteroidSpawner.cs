using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AsteroidSpawner : MonoBehaviour {
    // asteroid variants
    [SerializeField] private GameObject big1;
    [SerializeField] private GameObject big2;
    [SerializeField] private GameObject big3;
    [SerializeField] private GameObject med1;
    [SerializeField] private GameObject med2;
    [SerializeField] private GameObject med3;
    [SerializeField] private GameObject sml1;
    [SerializeField] private GameObject sml2;
    [SerializeField] private GameObject sml3;
    
    // fields
    [SerializeField] private float spawnTimeMean = 5f;
    [SerializeField] private float spawnTimeVar = 1f;
    [SerializeField] private float spawnRadius = 30f;
    [SerializeField] private float forceMean = 1f;
    [SerializeField] private float forceVar = 0.5f;
    [SerializeField] private float forceAnglePerturbation = 10f;
    [SerializeField] private float torqueMean = 0.1f;
    [SerializeField] private float torqueVar = 0.05f;
    
    private float nextSpawnTime = 0;
    private List<GameObject> asteroids;

    private void Start() {
        asteroids = new List<GameObject> { big1, big2, big3, med1, med2, med3, sml1, sml2, sml3 };
    }

    private void Update() {
        // if time to spawn,
        if (Time.time > nextSpawnTime) {
            
            // pick position on unit circle according to spawnRadius
            Vector2 normalizedSpawnPosition = Random.insideUnitCircle.normalized;
            
            // instantiate object
            int index = Random.Range(0, asteroids.Count - 1);
            GameObject spawned = Instantiate(asteroids[index], normalizedSpawnPosition * spawnRadius, Quaternion.identity);
            
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
            float timeStep = Random.Range(spawnTimeMean - spawnTimeVar, spawnTimeMean + spawnTimeVar);
            nextSpawnTime = Time.time + timeStep;
        }
    }
}
