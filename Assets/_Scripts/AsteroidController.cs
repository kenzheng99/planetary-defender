using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AsteroidController : MonoBehaviour {
    private GameManager gameManager;

    void Awake() {
        gameManager = GameManager.Instance;
    }
    private void OnCollisionEnter(Collision collision) {
        Collider collider = collision.collider;
        
        if (collider.CompareTag("Projectile")) {
            Destroy(gameObject);
            Destroy(collision.collider.gameObject);
            gameManager.AsteroidDestroyed(AsteroidSize.LARGE);
        } else if (collider.CompareTag("Planet")) {
            Destroy(gameObject);
            gameManager.AsteroidHitPlanet(AsteroidSize.LARGE);
        }
    }

    void Update() {
        // center asteroid in the Z axis
        Rigidbody asteroidRb = gameObject.GetComponent<Rigidbody>();
        asteroidRb.AddForce(new Vector3(0, 0, -transform.position.z), ForceMode.Force);
    }
}
