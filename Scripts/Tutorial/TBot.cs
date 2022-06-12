using UnityEngine;

public class TBot : MonoBehaviour
{
    public GameObject[] AllCards;
    private GameObject[] HCards = new GameObject[3];
    private GameObject[] cards = new GameObject[3];

    private int q;
    private int[] remove = new int[3];
    private int t = 18;

    public static GameObject card_1;
    public static GameObject card_2;
    public static GameObject card_3;

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

    public static float time;
    public static float timeToChange = 0.25f;
    public static bool starter = false;

    private bool OverFlow = false;

    public void Changer()
    {
        foreach (GameObject card in AllCards){
            card.GetComponent<Animator>().SetBool("End", true);
        }

        time = timeToChange;
        starter = true;
    }

    public void Update()
    {
        if (starter == true)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                if(TInf.SetsLeft != 0)
                {
                    Finder();
                    starter = false;
                }
            }
        }
    }

    public void Finder()
    {
        for (int i = 0; i < 3; i++)
        {
            q = Random.Range(0, 12);
            for (int f = 0; f < i; f++)
            {
                while (remove[f] == q)
                {
                    q = Random.Range(0, 12);
                }
            }
            remove[i] = q;
            cards[i] = AllCards[q];
        }

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
            if (t == 18)
            {
                t = 16;
            }
            while (t < 16)
            {
                if ((TInf.use[t] == (card_1.name + "_" + card_2.name + "_" + card_3.name)) ||
                    (TInf.use[t] == (card_1.name + "_" + card_3.name + "_" + card_2.name)) ||
                    (TInf.use[t] == (card_2.name + "_" + card_1.name + "_" + card_3.name)) ||
                    (TInf.use[t] == (card_2.name + "_" + card_3.name + "_" + card_1.name)) ||
                    (TInf.use[t] == (card_3.name + "_" + card_2.name + "_" + card_1.name)) ||
                    (TInf.use[t] == (card_3.name + "_" + card_1.name + "_" + card_2.name)))
                {
                    t = 0;
                    Finder();
                }
                t++;
            }
            if (t == 16)
            {
                string[] names = { card_1.name, card_2.name, card_3.name };
                for (int i = 0; i < 3; i++)
                {
                    HCards[i] = GameObject.Find(names[i]);
                    HCards[i].GetComponent<Animator>().SetBool("End", false);
                }
                t = 0;
            }
        }
        else
        {
            Finder();
        }
    }
}