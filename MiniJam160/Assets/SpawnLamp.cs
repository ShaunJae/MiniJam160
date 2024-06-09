using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLamp : MonoBehaviour
{
    [SerializeField] GameObject redLamp;
    [SerializeField] GameObject greenLamp;
    [SerializeField] GameObject whiteLamp;

    int randomNumber;
    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(1, 5);

        if (randomNumber == 1 || randomNumber == 2)
        {
            Instantiate(whiteLamp, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
        }

        if (randomNumber == 3)
        {
            Instantiate(redLamp, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
        }

        if (randomNumber == 4)
        {
            Instantiate(greenLamp, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
