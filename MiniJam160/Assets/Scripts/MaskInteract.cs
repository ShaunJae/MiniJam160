using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaskInteract : MonoBehaviour
{
    GameObject player;
    bool iGotCollected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!iGotCollected)
            {
                CollectMask script = other.gameObject.GetComponent<CollectMask>();
                script.PlayMaskSFX();
                script.masksCollected += 1;
                iGotCollected = true;
            }
            Destroy(this.gameObject, .2f);
        }
    }
}
