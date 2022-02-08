using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AsteroidController : MonoBehaviour {
    private UIController ui;

    void Awake() {
        ui = FindObjectOfType<UIController>();
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Projectile")) {
            Destroy(gameObject);
            Destroy(collision.collider.gameObject);
            ui.incrementCounter();
        };
    }

    void Update() {
        // center asteroid in the Z axis
        Rigidbody asteroidRb = gameObject.GetComponent<Rigidbody>();
        asteroidRb.AddForce(new Vector3(0, 0, -transform.position.z), ForceMode.Force);
    }
}
