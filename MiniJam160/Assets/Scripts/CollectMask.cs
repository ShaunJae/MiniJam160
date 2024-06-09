using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMask : MonoBehaviour
{
    public int masksCollected = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayMaskSFX()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
    }
}
