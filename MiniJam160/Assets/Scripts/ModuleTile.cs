using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleTile : MonoBehaviour {

    [HideInInspector] public List<Transform> connectors = new List<Transform>();

    [HideInInspector] public GameObject geometryContainer;

    void Awake() {

        foreach (Transform connector in transform.Find("Connectors")) {
            connectors.Add(connector);
        }

        geometryContainer = transform.Find("Geometry").gameObject;
        geometryContainer.SetActive(false);

        Invoke("DestroySelf", 5f);
    }

    void DestroySelf() {
        Destroy(gameObject);
    }

    public void OnDestroy() {
        MiniJam.moduleManager.RemoveMultipleConnectors(connectors);
    }
}
