using System.Collections;
using System;
using System.Timers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

    public Button spot_1;
    public Button spot_2;
    public Button spot_3;
    public Button spot_4;
    public Button spot_5;
    public GameObject check;

    public Button spot_1_pressed;
    public Button spot_2_pressed;
    public Button spot_3_pressed;
    public Button spot_4_pressed;
    public Button spot_5_pressed;
    public GameObject check_win;
    public GameObject check_lose;

    private bool pressed_spot_1;
    private bool pressed_spot_2;
    private bool pressed_spot_3;
    private bool pressed_spot_4;
    private bool pressed_spot_5;
    private bool pressed_check;

    public GameObject winningPanel;
    public GameObject losingPanel;

    SceneController _sceneController;

    const int _totalTaskNumber = 4;

    bool _isLose;

    public void press_1_spot()
    {
        pressed_spot_1 = true;
        spot_1.gameObject.SetActive(false);
        spot_1_pressed.gameObject.SetActive(true);
    }


    public void visible_1_spot()
    {
        pressed_spot_1 = false;
        spot_1.gameObject.SetActive(true);
        spot_1_pressed.gameObject.SetActive(false);
    }

    public void press_2_spot()
    {
        pressed_spot_2 = true;
        spot_2.gameObject.SetActive(false);
        spot_2_pressed.gameObject.SetActive(true);
    }


    public void visible_2_spot()
    {
        pressed_spot_2 = false;
        spot_2.gameObject.SetActive(true);
        spot_2_pressed.gameObject.SetActive(false);
    }

    public void press_3_spot()
    {
        pressed_spot_3 = true;
        spot_3.gameObject.SetActive(false);
        spot_3_pressed.gameObject.SetActive(true);
    }


    public void visible_3_spot()
    {
        pressed_spot_3 = false;
        spot_3.gameObject.SetActive(true);
        spot_3_pressed.gameObject.SetActive(false);
    }

    public void press_4_spot()
    {
        pressed_spot_4 = true;
        spot_4.gameObject.SetActive(false);
        spot_4_pressed.gameObject.SetActive(true);
    }


    public void visible_4_spot()
    {
        pressed_spot_4 = false;
        spot_4.gameObject.SetActive(true);
        spot_4_pressed.gameObject.SetActive(false);
    }

    public void press_5_spot()
    {
        pressed_spot_5 = true;
        spot_5.gameObject.SetActive(false);
        spot_5_pressed.gameObject.SetActive(true);
    }


    public void visible_5_spot()
    {
        pressed_spot_5 = false;
        spot_5.gameObject.SetActive(true);
        spot_5_pressed.gameObject.SetActive(false);
    }

    IEnumerator WaitForTry()
    {
        yield return new WaitForSeconds(1.0f);
        visible_1_spot();
        visible_2_spot();
        visible_3_spot();
        visible_4_spot();
        visible_5_spot();
        spot_1.interactable = true;
        spot_2.interactable = true;
        spot_3.interactable = true;
        spot_4.interactable = true;
        spot_5.interactable = true;
        spot_1_pressed.interactable = true;
        spot_2_pressed.interactable = true;
        spot_3_pressed.interactable = true;
        spot_4_pressed.interactable = true;
        spot_5_pressed.interactable = true;

        if (!_isLose && (HealthController.count != 0 || TimerController.currentTime != 0f))
        {
            check.gameObject.SetActive(true);
            check_lose.gameObject.SetActive(false);
            pressed_check = false; 
        }
    }

    public void CheckAnswer()
    {
        pressed_check = true;
        spot_1.interactable = false;
        spot_2.interactable = false;
        spot_3.interactable = false;
        spot_4.interactable = false;
        spot_5.interactable = false;
        spot_1_pressed.interactable = false;
        spot_2_pressed.interactable = false;
        spot_3_pressed.interactable = false;
        spot_4_pressed.interactable = false;
        spot_5_pressed.interactable = false;

        if (pressed_check && ((pressed_spot_1 && pressed_spot_2 && !pressed_spot_3 && !pressed_spot_4 && !pressed_spot_5) || ((!pressed_spot_1 && !pressed_spot_2 && pressed_spot_3 && pressed_spot_4) || pressed_spot_5)))
        {
            check.gameObject.SetActive(false);
            check_win.gameObject.SetActive(true);
            LevelWin();
        }
        else
        {
            --HealthController.count;
            check.gameObject.SetActive(false);
            check_lose.gameObject.SetActive(true);
            pressed_check = false;
            StartCoroutine(WaitForTry());
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

    // Start is called before the first frame update
    void Start()
    {
        pressed_spot_1 = false;
        pressed_spot_2 = false;
        pressed_spot_3 = false;
        pressed_spot_4 = false;
        pressed_spot_5 = false;
        pressed_check = false;

        _sceneController = gameObject.AddComponent<SceneController>();
        _isLose = false;

        String value = Utils.GetRegexMatchValue(_sceneController.GetActiveScene().name);

        if (value.Length > 2)
        {
            LevelNumberController.levelNumber = Int32.Parse(value[0].ToString());
            LevelNumberController.taskNumber = Int32.Parse(value[value.Length - 1].ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed_spot_1 || pressed_spot_2 || pressed_spot_3 || pressed_spot_4 || pressed_spot_5)
        {
            check.gameObject.SetActive(true);
        }
        else
        {
            check.gameObject.SetActive(false);
        }


        if (!_isLose && (HealthController.count == 0 || TimerController.currentTime == 0f))
        {
            LevelLose();
        }
    }
}
