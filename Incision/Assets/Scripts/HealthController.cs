using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public List<Image> hearts;
    public static int count;

    void Start()
    {
        count = hearts.Count;
    }

    void Update()
    {
        if (count < hearts.Count)
        {
            int index = hearts.Count - count;
            Utils.ChangeColorImage(hearts[index == hearts.Count ? 0 : index], Color.white);
        }
    }
}
