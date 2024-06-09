using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MiniJam {
    public static Transform sun;
    public static CanvasController canvasController;
    public static ModuleManager moduleManager;
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

    public static T WeightedRandom<T>(Dictionary<T, int> weightedDictionary) {
        int i;

        List<T> objects = weightedDictionary.Keys.ToList();
        List<int> weights = weightedDictionary.Values.ToList();

        List<int> cumulativeWeights = new List<int>(weights.Count);

        for (i = 0; i < weightedDictionary.Count; i++) {
            cumulativeWeights.Add(weights[i] + (i != 0 ? cumulativeWeights[i - 1] : 0));
        }

        float randomSelection = Random.Range(0f, cumulativeWeights[cumulativeWeights.Count - 1]);

        for (i = 0; i < cumulativeWeights.Count; i++) {
            if (cumulativeWeights[i] > randomSelection) {
                break;
            }
        }

        return objects[i];
    }
}
