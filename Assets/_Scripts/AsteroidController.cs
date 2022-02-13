using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AsteroidController : MonoBehaviour {
    private GameManager gameManager;

    void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Projectile")) {
            Destroy(gameObject);
            Destroy(collision.collider.gameObject);
            gameManager.incrementScore();
        };
    }

    void Update() {
        // center asteroid in the Z axis
        Rigidbody asteroidRb = gameObject.GetComponent<Rigidbody>();
        asteroidRb.AddForce(new Vector3(0, 0, -transform.position.z), ForceMode.Force);
    }
}
