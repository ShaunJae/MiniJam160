using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

    private RectTransform lightBar;

    void Start() {
        MiniJam.canvasController = this;
        lightBar = (RectTransform)transform.Find("BG/LightBar");
    }

    public void UpdateLightBar() {
        Vector3 newScale = lightBar.transform.localScale;
        newScale.y = MiniJam.health;
        lightBar.transform.localScale = newScale;
    }
}
