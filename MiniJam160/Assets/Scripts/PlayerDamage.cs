using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

    private Transform footLocation;
    private List<Transform> lightTriggers = new List<Transform>();

    void Start() {
        footLocation = transform.Find("Foot");
    }

    void FixedUpdate() {
        CheckLight();
    }

    void CheckLight() {

        RaycastHit hit;

        if (lightTriggers.Count > 0) {
            //Debug.Log(lightTriggers.Count);
            int shadowCount = 0;
            foreach (Transform lightPosition in lightTriggers) {

                Vector3 toLightVector = lightPosition.position - footLocation.position;
                if (Physics.Raycast(footLocation.position, toLightVector, out hit, toLightVector.magnitude)) {
                    shadowCount++;
                }

            }
            if (shadowCount == lightTriggers.Count) {
                MiniJam.ChangeHealth(-0.01f);
                return;
            } else {
                return;
            }
        }
        if (Physics.Raycast(footLocation.position, MiniJam.sun.forward * -1, out hit, Mathf.Infinity)) {
            MiniJam.ChangeHealth(-0.01f);
            return;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Light")) {
            lightTriggers.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Light")) {
            lightTriggers.Remove(other.transform);
        }
    }
}
