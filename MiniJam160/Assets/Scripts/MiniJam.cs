using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJam {
    public static Transform sun;
    public static CanvasController canvasController;
    public static float health = 1;
    public static float lastDamage = 0;
    public static float invulnTime = 0.25f;
    public static int score = 100;

    public static void ChangeHealth(float value) {
        health += value;
        if (value < 0 && Time.time - lastDamage > invulnTime) {

        }
        canvasController.UpdateLightBar();
    }
}
