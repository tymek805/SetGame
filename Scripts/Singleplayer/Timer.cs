using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject timer;
    public GameObject GeneralT;
    public GameObject End;

    public Text choise;
    public static float ChoisingTime;
    public static float TimeForChoise;

    public void Start()
    {
        TimeForChoise = ChoisingTime;
        Inf.startTimer = false;
        timer.SetActive(false);
    }

    public void Update()
    {
        if (Inf.startTimer && TimeForChoise > 0.0f)
        {
            End.GetComponent<BoxCollider>().enabled = false;
            MGeneralTimer.TimeToChange = MGeneralTimer.changingTime;
            Inf.wrong = false;
            GeneralT.SetActive(false);
            timer.SetActive(true);
            TimeForChoise -= Time.deltaTime;
            choise.text = "Time left: " + TimeForChoise.ToString("f0");
        }
        else if (Inf.startTimer)
        {
            End.GetComponent<BoxCollider>().enabled = true;
            Inf.wrong = true;
            Inf.reset_T = true;
            Inf.score--;
            Inf.startTimer = false;
            timer.SetActive(false);
            TimeForChoise = ChoisingTime;
        }
    }
}