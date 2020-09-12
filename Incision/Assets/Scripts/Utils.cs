using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Utils : MonoBehaviour
{
    public static void ChangeEnabledImage(Image image, bool value)
    {
        image.enabled = value;
    }

    public static void ChangeColorImage(Image image, Color color)
    {
        image.color = color;
    }

    public static void RotateImage(Image image)
    {
        image.transform.Rotate(0f, 0f, 90f);
    }

    public static String GetRegexMatchValue(string str)
    {
        return Regex.Match(str, @"[\d\.]+").Value;
    }
}
