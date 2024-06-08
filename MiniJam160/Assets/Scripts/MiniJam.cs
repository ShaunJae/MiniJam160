using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJam {
    public static Transform sun;
    public static CanvasController canvasController;
    public static float health = 1;
    public static float lastDamage = 0;
    public static float invulnTime = 0.05f;
    public static int score = 100;

    public static void ChangeHealth(float value) {
        if (value < 0 && Time.time - lastDamage < invulnTime) {
            return;
        } else {
            lastDamage = Time.time;
        }
        health += value;
        canvasController.UpdateLightBar();
    }
}
