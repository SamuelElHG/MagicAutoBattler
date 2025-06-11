using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clock : MonoBehaviour
{

    public float minutes = 1f; // Configurable desde el Inspector
    private float timeLeft;
    public TMP_Text timerText;

    private bool isRunning = false;

    void Update()
    {
        if (isRunning && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimerUI();

            if (timeLeft <= 0)
            {
                timeLeft = 0;
                isRunning = false;
                TimerEnded();
            }
        }
    }

    public void StartTimer()
    {
        timeLeft = minutes * 60f;
        isRunning = true;
        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutesLeft = Mathf.FloorToInt(timeLeft / 60f);
        int secondsLeft = Mathf.FloorToInt(timeLeft % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutesLeft, secondsLeft);
    }

    void TimerEnded()
    {
        Debug.Log("¡El tiempo se ha terminado!");
        GameOver();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
