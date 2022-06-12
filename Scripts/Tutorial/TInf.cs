using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TInf : MonoBehaviour
{
    public GameObject Confirm;

    public Text scoreText;
    public Text CardAmountText;

    public void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        CardAmountText.text = "Sets left: " + SetsLeft.ToString();
    }

    //wartości dla PrefabBack
    
    public static float position = 5.6f;
    public static new int name = 81;

    public static HashSet<int> used = new HashSet<int>();

    //1.25f poziomo -2.75x -3.8z
    //1.7f pionowo
    //y = 5.7f

    public static string[] use = new string[16];

    //Dla Gameplay
    public static int score = 0;
    public static string[] p_cards = new string[3];

    //Dla Pick
    public static bool wrong = true;
    public static bool reset_T = false;
    public static int t = 1;

    //Dla End
    public static int SetsLeft = 16;

    //Dla TBot


    /*                                          Wartości różne od TInf ~ MInf
    //Dla GeneralTimer
    public static bool rowC = true;
    public static bool cardC = true;

    //Dla End
    public static bool isEnding = false;
    */
}