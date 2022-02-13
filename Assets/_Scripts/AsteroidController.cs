using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AsteroidController : MonoBehaviour {
    private GameManager gameManager;
    private AsteroidSize asteroidSize;

    void Awake() {
        gameManager = GameManager.Instance;
        asteroidSize = GetAsteroidSize(gameObject);
    }
    private void OnCollisionEnter(Collision collision) {
        Collider collider = collision.collider;
        
        if (collider.CompareTag("Projectile")) {
            Destroy(gameObject);
            Destroy(collider.gameObject);
            gameManager.AsteroidDestroyed(asteroidSize);
        } else if (collider.CompareTag("Planet")) {
            Destroy(gameObject);
            gameManager.AsteroidHitPlanet(asteroidSize);
        }
    }

    private static AsteroidSize GetAsteroidSize(GameObject asteroid) {
        if (asteroid.CompareTag("AsteroidLarge")) {
            return AsteroidSize.LARGE;
        } else if (asteroid.CompareTag("AsteroidMedium")) {
            return AsteroidSize.MEDIUM;
        } else if (asteroid.CompareTag("AsteroidSmall")) {
            return AsteroidSize.SMALL;
        } else {
            throw new Exception("Asteroid has no tag");
        }
    }

    private void Update() {
        // center asteroid in the Z axis
        Rigidbody asteroidRb = gameObject.GetComponent<Rigidbody>();
        asteroidRb.AddForce(new Vector3(0, 0, -transform.position.z), ForceMode.Force);
    }
}
