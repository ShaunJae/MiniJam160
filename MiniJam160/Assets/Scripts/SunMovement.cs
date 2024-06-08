using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMovement : MonoBehaviour {

    Vector2 rotationPosition = Vector2.right * 90;
    Vector2 rotationDirection = Vector2.zero;

    void Start() {
        MiniJam.sun = transform;
        rotationDirection = Random.insideUnitCircle;
    }
    void Update() {
        RotateSun();
    }

    void RotateSun() {
        rotationPosition += rotationDirection;
        transform.rotation = Quaternion.Euler(rotationPosition.x, rotationPosition.y, 0);
    }
}
