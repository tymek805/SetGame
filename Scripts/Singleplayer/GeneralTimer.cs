using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralTimer : MonoBehaviour
{
    private Sprite normal;
    public Sprite back;

    public GameObject GeneralT;
    public GameObject timer;

    private GameObject[] cards = new GameObject[3];
    private GameObject newcard;

    private int r;
    private int c;

    public Text change;

    public static float changingTime;
    public static float TimeToChange;
    private readonly string[] x = {"row1", "row2", "row3", "row4"};
    private bool next = false;

    public void Start()
    {
        Inf.startGeneralT = false;
        GeneralT.SetActive(false);
    }

    public void Update()
    {
        if (Inf.CardAmount == 0)
        {
            Inf.startGeneralT = false;
        }
        if (Inf.startGeneralT && TimeToChange > 0.0f && !Inf.startTimer)
        {
            GeneralT.SetActive(true);
            timer.SetActive(false);
            TimeToChange -= Time.deltaTime;
            change.text = "Time to change: " + TimeToChange.ToString("f0");
        }
        else if (TimeToChange <= 0.0f && next == false && Inf.startGeneralT)
        {
            next = true;
            StartCoroutine(Change());
        }
    }
    IEnumerator Change()
    {
        GeneralT.SetActive(false);
        Inf.IsAnyAction = true;

        r = UnityEngine.Random.Range(1, 4);
        cards = GameObject.FindGameObjectsWithTag("row" + r.ToString());

        print("First: " + cards[0].name + ", second: " + cards[1].name + ", third: " + cards[2].name);

        for (int i = 0; i < 3; i++)
        {
            normal = cards[i].GetComponent<SpriteRenderer>().sprite;
            Inf.wrong = false;
            cards[i].GetComponent<SpriteRenderer>().sprite = back;
            c = UnityEngine.Random.Range(0, 80);

            while (Inf.used.Contains(c))
            {
                c = UnityEngine.Random.Range(0, 80);
            }

            yield return new WaitForSeconds(0.25f);
            Inf.wrong = true;
            newcard = GameObject.Find(Inf.names[c]);
            newcard.transform.position = cards[i].transform.position;

            newcard.tag = x[r-1];

            cards[i].transform.position = new Vector3(0, 0, 0);
            cards[i].GetComponent<SpriteRenderer>().sprite = normal;
            cards[i].tag = "Untagged";
            
            Inf.used.Add(c);
        }
        for (int i = 0; i < 3; i++)
        {
            int idx = Array.IndexOf(Inf.names, cards[i].name);
            Inf.used.Remove(idx);
        }
        StopCoroutine(Change());
        TimeToChange = changingTime;
        Inf.IsAnyAction = false;
        next = false;
    }
}