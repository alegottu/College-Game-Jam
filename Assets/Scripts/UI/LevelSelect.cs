using UnityEngine;
using System.Collections.Generic;

public class LevelSelect : MonoBehaviour
{
    private static Dictionary<int, string> levels = new Dictionary<int, string>
    {
        [0] = "Tutorial",
        [1] = "StageOne",
        [2] = "StageTwo",
        [3] = "StageThree"
    };

    public void OnClick(int level)
    {
        SceneController.Instance.LoadLevel(levels[level]);
    }
}
