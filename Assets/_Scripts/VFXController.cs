using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXController : MonoBehaviour {
    private void Start() {
        Destroy(gameObject, 1f);
    }
}
