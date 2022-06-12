using Photon.Pun;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MGeneralTimer : MonoBehaviourPun
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
    private readonly string[] x = { "row1", "row2", "row3", "row4" };
    private bool next = false;

    public void Start()
    {
        MInf.startGeneralT = false;
        GeneralT.SetActive(false);
    }

    public void Update()
    {
        if (MInf.CardAmount == 0)
        {
            MInf.startGeneralT = false;
        }
        if (MInf.startGeneralT && TimeToChange > 0.0f && !MInf.startTimer)
        {
            GeneralT.SetActive(true);
            timer.SetActive(false);
            TimeToChange -= Time.deltaTime;
            change.text = "Time to change: " + TimeToChange.ToString("f0");
        }
        else if (TimeToChange <= 0.0f && next == false && MInf.startGeneralT)
        {
            next = true;
            StartCoroutine(Change());
        }
    }

    public IEnumerator Change()
    {
        GeneralT.SetActive(false);
        MInf.IsAnyAction = true;
        photonView.RPC("TimeReset", RpcTarget.Others, MInf.IsAnyAction);

        if (PhotonNetwork.IsMasterClient)
        {
            r = Random.Range(1, 4);
            photonView.RPC("RowSearch", RpcTarget.All, r);
        }

        while (MInf.rowC == true)
        {
            yield return null;
        }
        //cards = GameObject.FindGameObjectsWithTag("row" + r.ToString());
        for (int i = 0; i < 3; i++)
        {
            normal = cards[i].GetComponent<SpriteRenderer>().sprite;
            MInf.wrong = false;
            cards[i].GetComponent<SpriteRenderer>().sprite = back;

            if (PhotonNetwork.IsMasterClient)
            {
                c = Random.Range(0, 80);
                while (MInf.used.Contains(c))
                {
                    c = Random.Range(0, 80);
                }
            }

            yield return new WaitForSeconds(0.25f);

            if (PhotonNetwork.IsMasterClient)
            {
                int[] variables = { c, r, i };

                photonView.RPC("SpriteSync", RpcTarget.All, variables);
            }

            while (MInf.cardC == true)
            {
                yield return null;
            }
        }
        for (int x = 0; x < 3; x++)
        {
            int idx = Array.IndexOf(MInf.names, cards[x].name);
            MInf.used.Remove(idx);
        }
        StopCoroutine(Change());
        TimeToChange = changingTime;
        MInf.IsAnyAction = false;
        photonView.RPC("TimeReset", RpcTarget.Others, MInf.IsAnyAction);
        next = false;
    }

    [PunRPC]
    public void TimeReset(bool checking)
    {
        if (!checking)
        {
            TimeToChange = changingTime;
            MInf.IsAnyAction = false;
        }
        else
        {
            MInf.IsAnyAction = true;
        }
    }

    [PunRPC]
    public void RowSearch(int row)
    {
        cards = GameObject.FindGameObjectsWithTag("row" + row.ToString());
        MInf.rowC = false;
    }

    [PunRPC]
    public void SpriteSync(int[] variables)
    {
        c = variables[0];
        r = variables[1];
        int i = variables[2];

        MInf.wrong = true;
        newcard = GameObject.Find(MInf.names[c]);
        newcard.transform.position = cards[i].transform.position;
        newcard.tag = x[r - 1];

        cards[i].transform.position = new Vector3(0, 0, 0);
        cards[i].GetComponent<SpriteRenderer>().sprite = normal;
        cards[i].tag = "Untagged";

        MInf.used.Add(c);
        MInf.cardC = false;
    }
}