using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LightAbsorb : MonoBehaviour
{
    Material mat;
    float tweenNumbers;
    bool playerIsIn = false;

    [SerializeField] GameObject pointLight;
    [SerializeField] GameObject lampPart;
    [SerializeField] ParticleSystem particles;

    [SerializeField] bool insantBreak;

    [SerializeField] bool tripleJump;
    [SerializeField] bool speed;
    [SerializeField] bool health;

    [SerializeField] PlayerMovement playerMoveScript;

    // Start is called before the first frame update
    void Start()
    {
        tweenNumbers = 1f;
        mat = new Material(GetComponent<Renderer>().material);
        GetComponent<Renderer>().material = mat;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsIn)
        {
            DrainMyColor();
            Color();
        }
    }
    void DrainMyColor()
    {
        tweenNumbers -= .3f * Time.deltaTime;

        if (insantBreak) tweenNumbers -= 1.5f * Time.deltaTime;
    }
    void Color()
    {
        if (tweenNumbers >= 0f)
        {
            Color emptyColor = new Color(tweenNumbers, tweenNumbers, tweenNumbers, 1);
            mat.SetColor("_EmissionColor", emptyColor);
        }
        else
        {
            if (speed)
            {
                playerMoveScript.speedPowerup = true;
            }
            if (tripleJump)
            {
                playerMoveScript.tripleJump = true;
            }

            particles.GetComponent<AudioSource>().Play();
            particles.Play();
            Destroy(lampPart);
            Destroy(pointLight);
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsIn = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsIn = false;
        }
    }
}
