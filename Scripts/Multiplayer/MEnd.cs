using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MEnd : MonoBehaviourPun
{
    public Light lt;
    public GameObject EndAsk;
    public GameObject EndWait;
    public GameObject scoreboard;
    public GameObject[] cards;
    public Text scoretext;
    public Text WText;

    public void OnMouseDown()
    {
        StartCoroutine(Lights());
        if (MInf.isEnding == false && !MInf.startTimer)
        {
            EndWait.SetActive(true);
            WText.text = "You want to end match.\n Waiting for opponent...";
            photonView.RPC("PauseTime", RpcTarget.All);
            photonView.RPC("Ask", RpcTarget.Others);
        }
    }
    IEnumerator Lights()
    {
        lt.intensity = 2;

        yield return new WaitForSeconds(0.25f);

        lt.intensity = 1;

        StopCoroutine(Lights());
    }

    [PunRPC]
    public void PauseTime()
    {
        for (int i = 1; i < 5; i++)
        {
            cards = GameObject.FindGameObjectsWithTag("row" + i);
            foreach (GameObject card in cards)
            {
                card.transform.position = new Vector3(card.transform.position.x, 0f, card.transform.position.z);
            }
        }
        ResumeMMenu.GameIsPaused = true;
        MInf.isEnding = true;

        MInf.startGeneralT = false;
    }

    [PunRPC]
    public void Ask()
    {
        EndAsk.SetActive(true);
    }

    public void NoBut()
    {
        EndAsk.SetActive(false);
        EndWait.SetActive(true);
        photonView.RPC("AfterNo", RpcTarget.All);
    }

    public void YesBut()
    {
        photonView.RPC("AfterYes", RpcTarget.Others, PhotonNetwork.NickName, MInf.score);
        EndAsk.SetActive(false);
    }

    [PunRPC]
    public void AfterNo()
    {
        MInf.startGeneralT = true; // Start Time
        ResumeMMenu.GameIsPaused = false;
        MInf.isEnding = false;
        StartCoroutine(TextChange());
    }

    IEnumerator TextChange()
    {
        string RText = WText.text;
        for(int i = 5; i > 0; i--)
        {
            WText.text = "End game request is deny. Game will be resumed in " + i;
            yield return new WaitForSeconds(1f);
        }

        for (int i = 1; i < 5; i++)
        {
            cards = GameObject.FindGameObjectsWithTag("row" + i);
            foreach (GameObject card in cards)
            {
                card.transform.position = new Vector3(card.transform.position.x, 5.7f, card.transform.position.z);
            }
        }

        WText.text = RText;
        MInf.isEnding = false;
        EndWait.SetActive(false);
        EndAsk.SetActive(false);
    }

    [PunRPC]
    public void AfterYes(string name, int score)
    {
        string textscore;
        EndWait.SetActive(false);
        if(score > MInf.score)
        {
            textscore = "Winner: \n" + name + " Score: " + score + "\n" + PhotonNetwork.NickName + " Score: " + MInf.score ;
            photonView.RPC("Scoreboard", RpcTarget.All, textscore);
        }
        else if(score < MInf.score)
        {
            textscore = "Winner: \n" + PhotonNetwork.NickName + " Score: " + MInf.score + "\n" + name + " Score: " + score;
            photonView.RPC("Scoreboard", RpcTarget.All, textscore);
        }
        else if(score == MInf.score)
        {
            textscore = "This is draw. \n Congratulations for both of you.\n" + "Yours score is " + score;
            photonView.RPC("Scoreboard", RpcTarget.All, textscore);
        }
        //StartCoroutine(Restarting());
        //Restart();
    }
    public void SubmitScoreButton()
    {
        PhotonNetwork.LeaveRoom();

        Restart();

        SceneManager.LoadScene("Multiplayer");
        SceneManager.LoadScene("Menu");
    }

    [PunRPC]
    public void Scoreboard(string tekst)
    {
        scoreboard.SetActive(true);
        scoretext.text = tekst;
    }

    public void Restart()
    {
        //MInf Reset
        MInf.position = 5.6f;
        MInf.x = -2f;
        MInf.z = -3.8f;
        MInf.name = 81;
        MInf.ready = false;

        MInf.used = new HashSet<int>();

        MInf.score = 0;                 //Dla Gameplay
        MInf.startTimer = false;        //Dla Timer
        MInf.startGeneralT = false;     //Dla GeneralTimer
        MInf.rowC = true;
        MInf.cardC = true;
        MInf.IsAnyAction = false;       //Dla Pick
        MInf.wrong = true;
        MInf.reset_T = false;
        MInf.t = 1;
        MInf.MMine = 0;
        MInf.masterHasstarted = false;  //Dla Multiplayer
        MInf.isEnding = false;          //Dla End
        MInf.CardAmount = 81;

        //Wszystko inne
        MPick.i = 1;
        ResumeMMenu.GameIsPaused = false;
    }
}