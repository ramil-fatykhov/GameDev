using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static float currentTime;
    Slider _timer;
    
    void Start()
    {
        currentTime = 30f;
        _timer = GetComponent<Slider>();
        _timer.maxValue = currentTime;
    }

    void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            _timer.value = currentTime;
        }
        else
        {
            currentTime = 0f;
        }
    }
}
