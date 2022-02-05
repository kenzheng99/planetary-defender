using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Projectile")) {
            Debug.Log("Earth Hit");
        }
    }
}
