using JetBrains.Annotations;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MInf : MonoBehaviourPun
{
    public GameObject Confirm;
    public GameObject starter;
    public GameObject deck;
    public GameObject scoreText;

    public Text CardAmountText;

    public void Start()
    {
        scoreText.transform.localPosition = new Vector3(-364.2f, 150f, 0f);
        deck.SetActive(false);
    }

    public void Update()
    {
        CardAmountText.text = "Cards left: " + CardAmount.ToString();

        if (ready == true)
        {
            deck.SetActive(true);
        }

        scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
    }

    //wartości dla PrefabBack

    public static float position = 5.6f;
    public static float x = -2f;
    public static float z = -3.8f;
    public static new int name = 81;
    public static bool ready = false;

    public static HashSet<int> used = new HashSet<int>();

    //1.25f poziomo -2.75x -3.8z
    //1.7f pionowo
    //y = 5.7f

    public static string[] names =
    {
        "0CE1", "0CE2", "0CE3", "0CF1", "0CF2", "0CF3", "0CR1", "0CR2", "0CR3",
        "0NE1", "0NE2", "0NE3", "0NF1", "0NF2", "0NF3", "0NR1", "0NR2", "0NR3", 
        "0ZE1", "0ZE2", "0ZE3", "0ZF1", "0ZF2", "0ZF3", "0ZR1", "0ZR2", "0ZR3",
        "1CE1", "1CE2", "1CE3", "1CF1", "1CF2", "1CF3", "1CR1", "1CR2", "1CR3",
        "1NE1", "1NE2", "1NE3", "1NF1", "1NF2", "1NF3", "1NR1", "1NR2", "1NR3",
        "1ZE1", "1ZE2", "1ZE3", "1ZF1", "1ZF2", "1ZF3", "1ZR1", "1ZR2", "1ZR3",
        "2CE1", "2CE2", "2CE3", "2CF1", "2CF2", "2CF3", "2CR1", "2CR2", "2CR3",
        "2NE1", "2NE2", "2NE3", "2NF1", "2NF2", "2NF3", "2NR1", "2NR2", "2NR3",
        "2ZE1", "2ZE2", "2ZE3", "2ZF1", "2ZF2", "2ZF3", "2ZR1", "2ZR2", "2ZR3",
    };

    //Dla Gameplay
    public static int score = 0;

    //Dla Timer
    public static bool startTimer = false;

    //Dla GeneralTimer
    public static bool startGeneralT = false;
    public static bool rowC = true;
    public static bool cardC = true;

    //Dla Pick
    public static bool IsAnyAction = false;
    public static bool wrong = true;
    public static bool reset_T = false;
    public static int t = 1;
    public static int MMine = 0;

    //Dla Multiplayer
    public static bool masterHasstarted = false;

    //Dla End
    public static bool isEnding = false;
    public static int CardAmount = 81;
}