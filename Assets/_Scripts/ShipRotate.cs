using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipRotate : MonoBehaviour {
    void Update() {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        float angle = Vector2.SignedAngle(Vector2.up, mouseWorldPosition - transform.position);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
