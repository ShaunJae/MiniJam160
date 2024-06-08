using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreatureMove : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MOVEMENT
        Vector3 creatureMovement = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.position = creatureMovement;


        //ROTATE
        Vector3 direction = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
}
