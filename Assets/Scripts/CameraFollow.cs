using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    void Start()
    {
        
    }
    
    void Update() {
        float targetAngle = target.transform.rotation.x;
        float cameraAngle = transform.rotation.eulerAngles.z;
        Debug.Log("targetx" +  targetAngle);
        Debug.Log("cameraz" +  cameraAngle);
        transform.rotation = target.transform.rotation;
    }
}
