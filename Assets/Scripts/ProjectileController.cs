using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] float maxDistance = 30;

    private void OnCollisionEnter(Collision collision) {
        Collider other = collision.collider;
        if (other.CompareTag("Planet")) {
            Debug.Log("Projectile Hit Planet");
            Destroy(gameObject);
        }
    }

    void Update() {
        Vector3 currentPos = transform.position;
        
        // Destroy projectile if too far from origin
        if (Mathf.Abs(currentPos.x) > maxDistance || Mathf.Abs(currentPos.y) > maxDistance || Mathf.Abs(currentPos.z) > maxDistance) {
            Destroy(gameObject);
        }
    }
}
