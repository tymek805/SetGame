using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public Light lt;
    public GameObject scoreboard;
    private GameObject card;
    public Text scoretext;

    public void OnMouseDown()
    {
        StartCoroutine(Restarting());
    }
    IEnumerator Restarting()
    {
        lt.intensity = 2;
        yield return new WaitForSeconds(0.25f);
        lt.intensity = 1;

        for(int i = 1; i < 5; i++)
        {
            for(int r = 1;r < 4; r++)
            {
                card = GameObject.FindGameObjectWithTag("row" + i.ToString());
                card.SetActive(false);
            }
        }
        AfterYes();
        StopCoroutine(Restarting());
    }

    public void Restart()
    {
        //Inf Reset
        Inf.reset = true;
        Inf.position = 5.6f;
        Inf.x = -2f;
        Inf.z = -3.8f;
        Inf.name = 81;
        Inf.ready = false;

        Inf.used = new HashSet<int>();

        Inf.score = 0;                 //Dla Gameplay
        Inf.startTimer = false;        //Dla Timer
        Inf.startGeneralT = false;     //Dla GeneralTimer
        Inf.IsAnyAction = false;       //Dla Pick
        Inf.wrong = true;
        Inf.reset_T = false;
        Inf.t = 1;
        Inf.CardAmount = 81;

        //Wszystko inne
        Pick.i = 1;
        ResumeMenu.GameIsPaused = false;

        if (PlayerPrefs.GetInt("Beginner") == 1)
        {
            PlayerPrefs.SetInt("Beginner", 0);
        }

        SceneManager.LoadScene("Singleplayer");
        SceneManager.LoadScene("Menu");
    }

    public void AfterYes()
    {
        string textscore;
        if (Inf.DummyScore > Inf.score)
        {
            textscore = "Winner: \n" + Inf.DummyName + " Score: " + Inf.DummyScore + "\n" + PhotonNetwork.NickName + " Score: " + Inf.score;
            Scoreboard(textscore);
        }
        else if (Inf.DummyScore < Inf.score)
        {
            textscore = "Winner: \n" + PhotonNetwork.NickName + " Score: " + Inf.score + "\n" + Inf.DummyName + " Score: " + Inf.DummyScore;
            Scoreboard(textscore);
        }
        else if (Inf.DummyScore == Inf.score)
        {
            textscore = "This is draw. \n Congratulations for both of you.\n" + "Yours score is " + Inf.DummyScore;
            Scoreboard(textscore);
        }
    }

    public void Scoreboard(string tekst)
    {
        scoreboard.SetActive(true);
        scoretext.text = tekst;
    }
}