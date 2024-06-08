using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

    private Transform footLocation;

    void Start() {
        footLocation = transform.Find("Foot");
    }

    void FixedUpdate() {
        RaycastHit hit;
        Debug.Log(MiniJam.sun.forward);
        if (Physics.Raycast(footLocation.position, MiniJam.sun.forward * -1, out hit, Mathf.Infinity)) {
            MiniJam.ChangeHealth(-0.01f);
        }
    }
}
