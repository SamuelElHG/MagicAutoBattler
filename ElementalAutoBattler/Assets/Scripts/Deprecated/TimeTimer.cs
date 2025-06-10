using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeTimer : MonoBehaviour
{
    public float minutes = 1f; // Puedes cambiar este valor desde el Inspector
    private float timeLeft;
    public TMP_Text timerText;

    void Start()
    {
        timeLeft = minutes * 60f;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            timeLeft = 0;
            TimerEnded();
        }
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
        // Aquí puedes agregar la lógica que quieras cuando se acabe el tiempo
    }
}
