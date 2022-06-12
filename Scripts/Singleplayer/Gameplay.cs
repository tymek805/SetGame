using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    private GameObject[] cards = new GameObject[3];

    public static GameObject card_1;
    public static GameObject card_2;
    public static GameObject card_3;

    public GameObject End;

    public Light lt;

    private float[] x = { -2f, -0.75f, 0.5f, 1.75f };
    private float p;

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

    private int i = 1;
    private int r;

    public void OnMouseDown()
    {
        StartCoroutine(Lights());
        Inf.startTimer = false;

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
            ((first_1 != first_2 && first_1 != first_3 && first_2 != first_3 &&
            second_1 == second_2 && second_1 == second_3 &&
            third_1 == third_2 && third_1 == third_3 &&
            fourth_1 == fourth_2 && fourth_1 == fourth_3) ||

            (first_1 == first_2 && first_1 == first_3 &&
            second_1 != second_2 && second_1 != second_3 && second_2 != second_3 &&
            third_1 == third_2 && third_1 == third_3 &&
            fourth_1 == fourth_2 && fourth_1 == fourth_3) ||

            (first_1 == first_2 && first_1 == first_3 &&
            second_1 == second_2 && second_1 == second_3 &&
            third_1 != third_2 && third_1 != third_3 && third_2 != third_3 &&
            fourth_1 == fourth_2 && fourth_1 == fourth_3) ||

            (first_1 == first_2 && first_1 == first_3 &&
            second_1 == second_2 && second_1 == second_3 &&
            third_1 == third_2 && third_1 == third_3 &&
            fourth_1 != fourth_2 && fourth_1 != fourth_2 && fourth_2 != fourth_3) ||


            (first_1 != first_2 && first_1 != first_3 && first_2 != first_3 &&
            second_1 != second_2 && second_1 != second_3 && second_2 != second_3 &&
            third_1 != third_2 && third_1 != third_3 && third_2 != third_3 &&
            fourth_1 != fourth_2 && fourth_1 != fourth_2 && fourth_2 != fourth_3) ||


            (first_1 == first_2 && first_1 == first_3 &&
            second_1 == second_2 && second_1 == second_3 &&
            third_1 != third_2 && third_1 != third_3 && third_2 != third_3 &&
            fourth_1 != fourth_2 && fourth_1 != fourth_2 && fourth_2 != fourth_3) ||

            (first_1 != first_2 && first_1 != first_3 && first_2 != first_3 &&
            second_1 != second_2 && second_1 != second_3 && second_2 != second_3 &&
            third_1 == third_2 && third_1 == third_3 &&
            fourth_1 == fourth_2 && fourth_1 == fourth_3) ||

            (first_1 != first_2 && first_1 != first_3 && first_2 != first_3 &&
            second_1 == second_2 && second_1 == second_3 &&
            third_1 == third_2 && third_1 == third_3 &&
            fourth_1 != fourth_2 && fourth_1 != fourth_2 && fourth_2 != fourth_3) ||

            (first_1 == first_2 && first_1 == first_3 &&
            second_1 != second_2 && second_1 != second_3 && second_2 != second_3 &&
            third_1 != third_2 && third_1 != third_3 && third_2 != third_3 &&
            fourth_1 == fourth_2 && fourth_1 == fourth_3) ||

            (first_1 != first_2 && first_1 != first_3 && first_2 != first_3 &&
            second_1 == second_2 && second_1 == second_3 &&
            third_1 != third_2 && third_1 != third_3 && third_2 != third_3 &&
            fourth_1 == fourth_2 && fourth_1 == fourth_3) ||

            (first_1 == first_2 && first_1 == first_3 &&
            second_1 != second_2 && second_1 != second_3 && second_2 != second_3 &&
            third_1 == third_2 && third_1 == third_3 &&
            fourth_1 != fourth_2 && fourth_1 != fourth_2 && fourth_2 != fourth_3) ||


            (first_1 == first_2 && first_1 == first_3 &&
            second_1 != second_2 && second_1 != second_3 && second_2 != second_3 &&
            third_1 != third_2 && third_1 != third_3 && third_2 != third_3 &&
            fourth_1 != fourth_2 && fourth_1 != fourth_2 && fourth_2 != fourth_3) ||

            (first_1 != first_2 && first_1 != first_3 && first_2 != first_3 &&
            second_1 == second_2 && second_1 == second_3 &&
            third_1 != third_2 && third_1 != third_3 && third_2 != third_3 &&
            fourth_1 != fourth_2 && fourth_1 != fourth_2 && fourth_2 != fourth_3) ||

            (first_1 != first_2 && first_1 != first_3 && first_2 != first_3 &&
            second_1 != second_2 && second_1 != second_3 && second_2 != second_3 &&
            third_1 == third_2 && third_1 == third_3 &&
            fourth_1 != fourth_2 && fourth_1 != fourth_2 && fourth_2 != fourth_3) ||

            (first_1 != first_2 && first_1 != first_3 && first_2 != first_3 &&
            second_1 != second_2 && second_1 != second_3 && second_2 != second_3 &&
            third_1 != third_2 && third_1 != third_3 && third_2 != third_3 &&
            fourth_1 == fourth_2 && fourth_1 == fourth_3)) &&
            Inf.t == 4
            )
        {
            while (i <= 3)
            {
                Inf.startTimer = false;

                r = Random.Range(0, 80);

                while (Inf.used.Contains(r))
                {
                    r = Random.Range(0, 80);
                }

                newcard = GameObject.Find(Inf.names[r]);

                if (!Inf.used.Contains(r) && newcard.name == Inf.names[r])
                {
                    if (i == 1)
                    {
                        newcard.transform.position = new Vector3(card_1.transform.position.x, card_1.transform.position.y, card_1.transform.position.z);
                    }
                    if (i == 2)
                    {
                        newcard.transform.position = new Vector3(card_2.transform.position.x, card_2.transform.position.y, card_2.transform.position.z);
                    }
                    if (i == 3)
                    {
                        newcard.transform.position = new Vector3(card_3.transform.position.x, card_3.transform.position.y, card_3.transform.position.z);
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        p = newcard.transform.position.x;
                        if (p == x[i])
                        {
                            newcard.tag = "row" + (i + 1).ToString();
                        }
                    }

                    Inf.used.Add(r);
                }
                Inf.CardAmount--;
                i++;
            }

            card_1.tag = "Untagged";
            card_2.tag = "Untagged";
            card_3.tag = "Untagged";

            card_1.SetActive(false);
            card_2.SetActive(false);
            card_3.SetActive(false);

            GeneralTimer.TimeToChange = GeneralTimer.changingTime;
            Timer.TimeForChoise = Timer.ChoisingTime;

            Inf.wrong = true;
            Pick.i = 1;
            i = 1;
            Inf.score++;
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                string name = cards[i].name;
                GameObject mcard = GameObject.Find(name);
                float p = mcard.transform.position.x;

                Inf.startTimer = false;

                GeneralTimer.TimeToChange = GeneralTimer.changingTime;
                Timer.TimeForChoise = Timer.ChoisingTime;

                Inf.wrong = true;
                Inf.reset_T = true;

                for (int r = 0; r < 4; r++)
                {
                    if (p == x[r])
                    {
                        mcard.tag = "row" + (r + 1).ToString();
                    }
                }
            }


            Pick.i = 1;
            Inf.score--;
        }

        End.GetComponent<BoxCollider>().enabled = true;
        Inf.reset_T = true;
        Inf.wrong = true;
    }
    IEnumerator Lights()
    {
        lt.intensity = 2;
        yield return new WaitForSeconds(0.25f);
        lt.intensity = 1;
        StopCoroutine(Lights());
    }
}