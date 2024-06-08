using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounceMask : MonoBehaviour
{
    float startingHeight;
    // Start is called before the first frame update
    void Start()
    {
        startingHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 1f, 0f);

        Vector3 newPos = transform.position;
        newPos.y = startingHeight + Mathf.Sin(Time.time * 3) * 0.25f;
        transform.position = newPos;

    }
    void MoveUp()
    {
        transform.DOMoveY(transform.position.y + 1, 1f).SetEase(Ease.InSine).onComplete = MoveDown;
    }
    void MoveDown()
    {
        transform.DOMoveY(transform.position.y - 1, 1f).SetEase(Ease.InSine).onComplete = MoveUp;
    }
}
