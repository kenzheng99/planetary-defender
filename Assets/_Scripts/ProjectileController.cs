using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] float maxDistance = 30;
    [SerializeField] private GameObject explosionVFX;
    
    private GameManager gameManager;

    private void Awake() {
        gameManager = GameManager.Instance;
    }

    private void OnCollisionEnter(Collision collision) {
        Collider other = collision.collider;
        if (other.CompareTag("Planet")) {
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
            gameManager.ProjectileHitPlanet();
        }
    }

    private void Update() {
        Vector3 currentPos = transform.position;
        
        // Destroy projectile if too far from origin
        if (Mathf.Abs(currentPos.x) > maxDistance || Mathf.Abs(currentPos.y) > maxDistance || Mathf.Abs(currentPos.z) > maxDistance) {
            Destroy(gameObject);
        }
    }
}
