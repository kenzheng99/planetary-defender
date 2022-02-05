using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SmoothRotate: MonoBehaviour
{
    [SerializeField, Tooltip("Input smooth damp speed.")]
    private float smoothInputSpeed = .2f;
    [SerializeField, Tooltip("Max movement speed")]
    private float maxSpeed = 20;

    private float input;
    private float currentMovement;
    private float currentVelocity;

    private void OnMove(InputValue movementValue) {
        input = movementValue.Get<Vector2>().x;
    }

    // Update is called once per frame
    void Update() {
        currentMovement = Mathf.SmoothDamp(currentMovement, input, ref currentVelocity, smoothInputSpeed);
        Debug.Log(currentMovement);
        transform.RotateAround(Vector3.zero, Vector3.back, currentMovement * maxSpeed * Time.deltaTime);
    }
}
