using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDELETETHIS : MonoBehaviour
{
    float myZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myZ = transform.position.z;
        myZ += 15f * Time.deltaTime;

        transform.position = new Vector3(transform.position.x, transform.position.y, myZ);
    }
}
