using UnityEngine;
using UnityEngine.UI;

public class MTimer : MonoBehaviour
{
    public GameObject timer;
    public GameObject GeneralT;
    public Button MEnd;

    public Text choise;
    public static float ChoisingTime;
    public static float TimeForChoise;

    public void Start()
    {
        TimeForChoise = ChoisingTime;
        MInf.startTimer = false;
        timer.SetActive(false);
    }

    public void Update()
    {
        if (MInf.startTimer && TimeForChoise > 0.0f)
        {
            MEnd.interactable = false;
            MGeneralTimer.TimeToChange = MGeneralTimer.changingTime;
            MInf.wrong = false;
            GeneralT.SetActive(false);
            timer.SetActive(true);
            TimeForChoise -= Time.deltaTime;
            choise.text = "Time left: " + TimeForChoise.ToString("f0");
        }
        else if (MInf.startTimer)
        {
            MEnd.interactable = true;
            MInf.MMine = 0;
            MInf.wrong = true;
            MInf.reset_T = true;
            MInf.score--;
            MInf.startTimer = false;
            timer.SetActive(false);
            TimeForChoise = ChoisingTime;
        }
    }
}