using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMovement : MonoBehaviour {

    void Start() {
        MiniJam.sun = transform;
        RotateSun();
    }
    void Update() {
        
    }

    void RotateSun() {
        transform.DORotate(SelectPosition(), Random.Range(2, 4)).SetEase(Ease.Linear).onComplete = RotateSun;
    }

    Vector3 SelectPosition() {
        return new Vector3(
            Random.Range(25, 155),
            Random.Range(0, 360),
            0
        );
    }
}
