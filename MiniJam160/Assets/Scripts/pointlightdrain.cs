using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointlightdrain : MonoBehaviour
{
    bool isDraining = false;
    Light pointLight;
    [SerializeField] bool insantBreak;
    // Start is called before the first frame update
    void Start()
    {
        pointLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDraining)
        {
            pointLight.intensity -= .6f * Time.deltaTime;
            if (insantBreak)
            {
                pointLight.intensity -= 1f * Time.deltaTime;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isDraining = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isDraining = false;
        }
    }
}
