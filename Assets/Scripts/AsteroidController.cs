using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Projectile")) {
            Destroy(gameObject);
            Destroy(collision.collider.gameObject);
        };
    }

    void Update() {
        // center asteroid in the Z axis
        Rigidbody asteroidRb = gameObject.GetComponent<Rigidbody>();
        asteroidRb.AddForce(new Vector3(0, 0, -transform.position.z), ForceMode.Force);
    }
}
