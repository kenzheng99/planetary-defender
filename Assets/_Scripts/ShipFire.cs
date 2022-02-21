using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class ShipFire : MonoBehaviour {
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private VisualEffect muzzleFlash;
    
    [SerializeField] float projectileForce = 20;
    [SerializeField] float cooldownTime = .5f;

    private GameManager gameManager;
    private float lastFiredAt = .0f;

    private void Awake() {
        gameManager = GameManager.Instance;
        lastFiredAt = Time.time;
    }

    private void Start() {
        lastFiredAt = Time.time;
    }

    private void OnFire(InputValue val) {
        Fire();
    }

    private void Fire() {
        if (lastFiredAt != .0f && lastFiredAt + cooldownTime > Time.time) {
            return;
        }
        
        GameObject projectileInstance = Instantiate(projectile, spawnLocation.position, transform.rotation);
        Rigidbody projectileRb = projectileInstance.GetComponent<Rigidbody>();
        projectileRb.AddForce(transform.up * projectileForce, ForceMode.Impulse);
        lastFiredAt = Time.time;
        muzzleFlash.Play();
        gameManager.ProjectileFired();
    }
}
