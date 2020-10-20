using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelNumberController : MonoBehaviour
{
    public List<Image> taskPoints;
    public static int levelNumber = 0;
    public static int taskNumber = 0;
    public TextMeshProUGUI level;

    void Update()
    {
        level.text = levelNumber.ToString();

        for(int i = 0; i < taskNumber; ++i)
        {
           Utils.ChangeColorImage(taskPoints[i], new Color32(255, 0, 0, 255));
        }
    }
}
