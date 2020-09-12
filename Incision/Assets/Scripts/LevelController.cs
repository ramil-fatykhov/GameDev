using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public GameObject winningPanel;
    public GameObject losingPanel;

    SceneController _sceneController;
    bool _isUpdate;

    const int _totalTaskNumber = 4;

    bool _isLose;

    void Start()
    {
        _sceneController = gameObject.AddComponent<SceneController>();
        _isUpdate = true;
        _isLose = false;

        String value = Utils.GetRegexMatchValue(_sceneController.GetActiveScene().name);

        if (value.Length > 2)
        {
            LevelNumberController.levelNumber = Int32.Parse(value[0].ToString());
            LevelNumberController.taskNumber = Int32.Parse(value[value.Length - 1].ToString());
        }
    }

    void Update()
    {
        if (!_isLose && (HealthController.count == 0 || TimerController.currentTime == 0f))
        {
            LevelLose();
        }
    }

    void LevelWin()
    {
        int nextBuildIndex = _sceneController.GetActiveScene().buildIndex + 1;

        if (LevelNumberController.taskNumber < _totalTaskNumber)
        {
            _sceneController.LoadNextSceneAfterWaiting();
        }
        else
        {
            _sceneController.panel = winningPanel;
            _sceneController.StopGame();
        }
    }

    void LevelLose()
    {
        _sceneController.panel = losingPanel;
        _sceneController.StopGame();
        _isLose = true;
    }
}
