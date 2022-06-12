using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGameplay : MonoBehaviourPun
{
    private GameObject[] cards = new GameObject[3];

    public static GameObject card_1;
    public static GameObject card_2;
    public static GameObject card_3;

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
        if (MInf.MMine == 0 && MInf.t == 4)
        {
            
            StartCoroutine(Lights());

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
                (first_1 != first_2 && first_1 != first_3 && first_2 != first_3 &&
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
                fourth_1 == fourth_2 && fourth_1 == fourth_3)
                )
            {
                while(i <= 3)
                {
                    r = Random.Range(0, 80);
                    while (MInf.used.Contains(r))
                    {
                        r = Random.Range(0, 80);
                    }
                    GameObject[] pickedcards = GameObject.FindGameObjectsWithTag("picked");
                    string[] names = { pickedcards[0].name, pickedcards[1].name, pickedcards[2].name};
                    photonView.RPC("Refill", RpcTarget.All, r, names, i);
                    MInf.CardAmount--;
                    i++;
                }

                MPick.i = 1;
                i = 1;
                MInf.score++;
            }
            else
            {
                for(int i = 0; i < 3; i++)
                {
                    string name = cards[i].name;
                    photonView.RPC("WrongSet", RpcTarget.All, name);
                }
                MInf.score--;
            }
            MInf.reset_T = true;
        }
    }

    [PunRPC]
    public void WrongSet(string CardName)
    {
        GameObject mcard = GameObject.Find(CardName);
        float p = mcard.transform.position.x;

        photonView.RPC("CardVisiable", RpcTarget.All, CardName);

        MInf.startTimer = false;

        MGeneralTimer.TimeToChange = MGeneralTimer.changingTime;
        MTimer.TimeForChoise = MTimer.ChoisingTime;

        MInf.MMine = 0;
        MInf.wrong = true;

        for (int i = 0; i < 4; i++)
        {
            if (p == x[i])
            {
                mcard.tag = "row" + (i + 1).ToString();
            }
        }

        MPick.i = 1;

        if (MInf.MMine == 1)
        {
            MInf.MMine = 0;
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
    public void Refill(int rand,string[] names, int c)
    {
        MInf.startTimer = false;
        r = rand;
        print(r);

        card_1 = GameObject.Find(names[0]);
        card_2 = GameObject.Find(names[1]);
        card_3 = GameObject.Find(names[2]);

        newcard = GameObject.Find(MInf.names[r]);
        print(newcard.name);

        if (!MInf.used.Contains(r))
        {
            if (c == 1)
            {
                newcard.transform.position = card_1.transform.position;
            }
            if (c == 2)
            {
                newcard.transform.position = card_2.transform.position;
            }
            if (c == 3)
            {
                newcard.transform.position = card_3.transform.position;
            }

            for (int i = 0; i < 4; i++)
            {
                p = newcard.transform.position.x;
                if (p == x[i])
                {
                    newcard.tag = "row" + (i + 1).ToString();
                }
            }

            MInf.used.Add(r);
        }
        if(c == 3)
        {
            card_1.tag = "Untagged";
            card_2.tag = "Untagged";
            card_3.tag = "Untagged";

            card_1.SetActive(false);
            card_2.SetActive(false);
            card_3.SetActive(false);

            MGeneralTimer.TimeToChange = MGeneralTimer.changingTime;
            MTimer.TimeForChoise = MTimer.ChoisingTime;

            MInf.MMine = 0;
            MInf.wrong = true;
        }
    }
}