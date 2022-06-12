using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TGameplay : MonoBehaviour
{
    private GameObject[] cards = new GameObject[3];

    public static GameObject card_1;
    public static GameObject card_2;
    public static GameObject card_3;

    public GameObject Warning;
    public GameObject End;

    public Text warningText;

    public Light lt;

    private float[] x = { -2f, -0.75f, 0.5f, 1.75f };
    private float p;

    private int t = 0;

    private int first_1 = new int();
    private char second_1 = new char();
    private char third_1 = new char();
    private int fourth_1 = new int();

    private int first_2 = new int();
    private char second_2 = new char();
    private char third_2 = new char();
    private int fourth_2 = new int();

    private int first_3 = new int();
    private char second_3 = new char();
    private char third_3 = new char();
    private int fourth_3 = new int();

    public static GameObject newcard;

    public void OnMouseDown()
    {
        StartCoroutine(Lights());

        if (TInf.t == 4)
        {
            cards = GameObject.FindGameObjectsWithTag("picked");

            card_1 = cards[0];
            card_2 = cards[1];
            card_3 = cards[2];

            first_1 = int.Parse(card_1.name[0].ToString());
            second_1 = card_1.name[1];
            third_1 = card_1.name[2];
            fourth_1 = int.Parse(card_1.name[3].ToString());

            first_2 = int.Parse(card_2.name[0].ToString());
            second_2 = card_2.name[1];
            third_2 = card_2.name[2];
            fourth_2 = int.Parse(card_2.name[3].ToString());

            first_3 = int.Parse(card_3.name[0].ToString());
            second_3 = card_3.name[1];
            third_3 = card_3.name[2];
            fourth_3 = int.Parse(card_3.name[3].ToString());

            if (
                (
                (first_1 == first_2) && (first_2 == first_3) && (first_3 == first_1) ||
                (first_1 != first_2) && (first_2 != first_3) && (first_3 != first_1)
                ) &&

                (
                (second_1 == second_2) && (second_2 == second_3) && (second_3 == second_1) ||
                (second_1 != second_2) && (second_2 != second_3) && (second_3 != second_1)
                ) &&

                (
                (third_1 == third_2) && (third_2 == third_3) && (third_3 == third_1) ||
                (third_1 != third_2) && (third_2 != third_3) && (third_3 != third_1)
                ) &&

                (
                (fourth_1 == fourth_2) && (fourth_2 == fourth_3) && (fourth_3 == fourth_1) ||
                (fourth_1 != fourth_2) && (fourth_2 != fourth_3) && (fourth_3 != fourth_1)
                )
               )
            {
                TBot.starter = false;

                if (TInf.score == 0)
                {
                    TInf.use[TInf.score] = card_1.name + "_" + card_2.name + "_" + card_3.name;
                    TInf.score++;
                    TInf.SetsLeft--;
                    t = 17;
                }

                while (t < 16)
                {
                    if ((TInf.use[t] == card_1.name + "_" + card_2.name + "_" + card_3.name) ||
                        (TInf.use[t] == card_1.name + "_" + card_3.name + "_" + card_2.name) ||
                        (TInf.use[t] == card_2.name + "_" + card_1.name + "_" + card_3.name) ||
                        (TInf.use[t] == card_2.name + "_" + card_3.name + "_" + card_1.name) ||
                        (TInf.use[t] == card_3.name + "_" + card_2.name + "_" + card_1.name) ||
                        (TInf.use[t] == card_3.name + "_" + card_1.name + "_" + card_2.name))
                    {
                        StartCoroutine(alreadyPicked());
                        t = 16;
                    }
                    t++;
                }

                if (t != 17)
                {
                    TInf.use[TInf.score] = card_1.name + "_" + card_2.name + "_" + card_3.name;
                    TInf.score++;
                    TInf.SetsLeft--;
                }

                t = 0;
            }

            for (int i = 0; i < 3; i++)
            {
                p = cards[i].transform.position.x;

                for (int r = 0; r < 4; r++)
                {
                    if (p == x[r])
                    {
                        cards[i].tag = "row" + (r + 1).ToString();
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                TInf.p_cards[i] = cards[i].name;
            }

            End.GetComponent<BoxCollider>().enabled = true;
            TInf.reset_T = true;

            TBot.timeToChange += 1f;
            TBot.time = TBot.timeToChange;
            TBot.starter = true;

            TInf.t = 1;
            TPick.i = 1;
            TInf.wrong = true;
        }
        else
        {
            Warning.SetActive(true);
            StartCoroutine(_errorWarning());
        }
    }

    IEnumerator _errorWarning()
    {
        Warning.SetActive(true);
        warningText.text = "Pick correct amount of cards";
        yield return new WaitForSeconds(1f);
        Warning.SetActive(false);
        StopCoroutine(_errorWarning());
    }

    IEnumerator alreadyPicked()
    {
        Warning.SetActive(true);
        warningText.text = "You have already picked that one";
        yield return new WaitForSeconds(1f);
        Warning.SetActive(false);
        StopCoroutine(alreadyPicked());
    }

    IEnumerator Lights()
    {
        lt.intensity = 2;
        yield return new WaitForSeconds(0.25f);
        lt.intensity = 1;
        StopCoroutine(Lights());
    }
}