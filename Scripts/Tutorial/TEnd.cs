using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TEnd : MonoBehaviour
{
    public Light lt;
    public GameObject scoreboard;
    public GameObject cards;
    public Text scoretext;

    public GameObject Warning;
    public Text warningText;

    public GameObject askPref;

    public void OnMouseDown()
    {
        if(TInf.SetsLeft > 9)
        {
            StartCoroutine(NotEnough());
        }
        else
        {
            StartCoroutine(Restarting());
        }
    }

    IEnumerator NotEnough()
    {
        lt.intensity = 2;
        yield return new WaitForSeconds(0.25f);
        lt.intensity = 1;

        Warning.SetActive(true);
        warningText.text = (8 - TInf.score) + " sets left";

        yield return new WaitForSeconds(1f);

        Warning.SetActive(false);
        StopCoroutine(NotEnough());
    }

    IEnumerator Restarting()
    {
        lt.intensity = 2;
        yield return new WaitForSeconds(0.25f);
        lt.intensity = 1;

        cards.SetActive(false);
        askPref.SetActive(true);

        StopCoroutine(Restarting());
    }

    public void Restart()
    {
        TInf.position = 5.6f;               //TInf Reset
        TInf.name = 81;

        TInf.used = new HashSet<int>();
        TInf.use = new string[16];

        TInf.score = 0;                     //Dla Gameplay
        TInf.p_cards = new string[3];

        TInf.wrong = true;                  //Dla Pick
        TInf.reset_T = false;
        TInf.t = 1;

        TInf.SetsLeft = 16;                 //Dla End

        TPick.i = 1;                        //Wszystko inne
        TResumeMenu.GameIsPaused = false;  

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Singleplayer");
    }

    public void AfterYes()
    {
        string textscore  = "You have found " + (16 - TInf.SetsLeft) + " sets.";
        askPref.SetActive(false);
        scoreboard.SetActive(true);
        scoretext.text = textscore;
    }

    public void AfterNo()
    {
        askPref.SetActive(false);
        cards.SetActive(true);
    }
}