using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class ShipFire : MonoBehaviour {
    [SerializeField] GameObject projectile;
    [SerializeField] Transform spawnLocation;
    [SerializeField] private VisualEffect muzzleFlash;
    
    [SerializeField] float projectileForce = 20;
    [SerializeField] float cooldownTime = .5f;

    private float lastFiredAt = .0f;

    private void OnFire(InputValue val) {
        Fire();
    }

    public void Fire() {
        if (lastFiredAt != .0f && lastFiredAt + cooldownTime > Time.time) {
            return;
        }
        
        GameObject projectileInstance = Instantiate(projectile, spawnLocation.position, transform.rotation);
        Rigidbody projectileRB = projectileInstance.GetComponent<Rigidbody>();
        projectileRB.AddForce(transform.up * projectileForce, ForceMode.Impulse);
        lastFiredAt = Time.time;
        muzzleFlash.Play();
    }
}
