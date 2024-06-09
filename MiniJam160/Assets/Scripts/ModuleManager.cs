using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ModuleManager : MonoBehaviour {

    //private HashSet<Transform> availableConnectors = new HashSet<Transform>();
    [HideInInspector] public Dictionary<Vector3, HashSet<Transform>> availableConnectors = new Dictionary<Vector3, HashSet<Transform>>();

    [Serializable] public struct WeightedTile {
        public GameObject module;
        public int weight;
    }

    public List<WeightedTile> exposedGenericModules = new List<WeightedTile>();
    private Dictionary<GameObject, int> genericModules = new Dictionary<GameObject, int>();

    void Start() {
        MiniJam.moduleManager = this;

        for (int i = 0; i < exposedGenericModules.Count; i++) {
            genericModules.Add(exposedGenericModules[i].module, exposedGenericModules[i].weight);
        }

        GameObject newModule = Instantiate(MiniJam.WeightedRandom<GameObject>(genericModules));
        ModuleTile moduleScript = GetModuleScript(newModule);
        moduleScript.geometryContainer.SetActive(true);
        AddMultipleConnectors(moduleScript.connectors);
        //availableConnectors.UnionWith(moduleScript.connectors);
        PlaceModule();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            PlaceModule();
        }
    }

    void PlaceModule() {
        GameObject newModule = Instantiate(MiniJam.WeightedRandom<GameObject>(genericModules));
        ModuleTile moduleScript = GetModuleScript(newModule);

        //Connector selection
        int newConnectorIndex = Random.Range(0, moduleScript.connectors.Count);
        Transform newConnector = moduleScript.connectors[newConnectorIndex];
        Transform existingConnector = PickConnector();

        //Rotation code
        Vector3 goalRotation = existingConnector.forward * -1;

        float rotationDelta = Vector3.SignedAngle(newConnector.forward, goalRotation, Vector3.up);

        newModule.transform.rotation = transform.rotation * Quaternion.AngleAxis(rotationDelta, Vector3.up);

        //Position code
        Vector3 positionDelta = existingConnector.position - newConnector.position;
        newModule.transform.position += positionDelta;

        //Enable geometry for box check
        moduleScript.geometryContainer.SetActive(true);
        
        //Check box has space and try at least 100 times before giving up
        BoxCollider moduleBox = newModule.GetComponent<BoxCollider>();
        int tries = 0;
        while (tries < 100 && Physics.CheckBox(newModule.transform.position + moduleBox.center, moduleBox.size / 2, newModule.transform.rotation, LayerMask.NameToLayer("ModuleCollision"), QueryTriggerInteraction.Collide)) {

            //Connector selection
            existingConnector = PickConnector(); //availableConnectors.Values.ToList()[Random.Range(0, availableConnectors.Count)];

            //Rotation code
            goalRotation = existingConnector.forward * -1;

            rotationDelta = Vector3.SignedAngle(newConnector.forward, goalRotation, Vector3.up);

            newModule.transform.rotation = transform.rotation * Quaternion.AngleAxis(rotationDelta, Vector3.up);

            //Position code
            positionDelta = existingConnector.position - newConnector.position;
            newModule.transform.position += positionDelta;

            tries++;
        }

        if (tries != 100) {

            AddMultipleConnectors(moduleScript.connectors);

            RemoveConnector(newConnector);
            RemoveConnector(existingConnector);

        } else {
            Destroy(newModule);
        }



        //1. Pick a module to place
        //2. Pick one of its connectors
        //3. Pick a existing connector
        //4. Rotate new module to match setp 2 up with step 3 (180° seperation)
        //5. Check collision
        //    If colliding, repeat step 3 and 4
        //6. Reveal geometry
        //7. Remove connectors from available
    }

    Transform PickConnector() {
        HashSet<Transform> selectedSet = availableConnectors.Values.ToList()[Random.Range(0, availableConnectors.Count)];
        while (selectedSet.Count != 1) {
            selectedSet = availableConnectors.Values.ToList()[Random.Range(0, availableConnectors.Count)];
        }
        return selectedSet.ToList()[0];
    }

    ModuleTile GetModuleScript(GameObject module) {
        return module.GetComponent<ModuleTile>();
    }

    public void AddMultipleConnectors(List<Transform> connectorList) {
        foreach (Transform connector in connectorList) {
            AddConnector(connector);
        }
    }

    public void AddConnector(Transform connector) {
        if (availableConnectors.ContainsKey(connector.position)) {
            availableConnectors[connector.position].Add(connector);
        } else {
            availableConnectors.Add(connector.position, new HashSet<Transform>() { connector });
        }
    }

    public void RemoveMultipleConnectors(List<Transform> connectorList) {
        foreach (Transform connector in connectorList) {
            RemoveConnector(connector);
        }
    }

    public void RemoveConnector(Transform connector) {
        //Check if set has pos of vector and if that set has transform, then remove it
        if (availableConnectors.ContainsKey(connector.position) && availableConnectors[connector.position].Contains(connector)) {
            availableConnectors[connector.position].Remove(connector);

            //If said pos now contains an empty set, clean it from dictionary
            if (availableConnectors[connector.position].Count == 0) {
                availableConnectors.Remove(connector.position);
            }
        }
    }
    
}
