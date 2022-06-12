using Photon.Pun;
using System.Collections;
using UnityEngine;

public class MShuffle : MonoBehaviourPun
{
    private GameObject real;
    [SerializeField] private GameObject deck;
    private int i = 0;
    private float[] x = { -2f, -0.75f, 0.5f, 1.75f };
    private float p;
    private int r;

    void Start()
    {
        gameObject.SetActive(true);
        while (i < 81)
        {
            gameObject.transform.position = new Vector3(6, MInf.position, 1);
            MInf.position += 0.00006f;
            i++;
        }
    }

    public void Update()
    {
        if (gameObject.name == "Karta (" + MInf.name + ")" && MInf.ready == true)
        {
            if (MInf.name > 78)
            {
                gameObject.transform.position = new Vector3(MInf.x, 5.7f, MInf.z);
                MInf.x += 1.25f;
            }

            if (MInf.name < 78 && MInf.name > 74)
            {
                gameObject.transform.position = new Vector3(MInf.x, 5.7f, MInf.z);
                MInf.x -= 1.25f;
            }

            if (MInf.name < 74 && MInf.name > 70)
            {
                gameObject.transform.position = new Vector3(MInf.x, 5.7f, MInf.z);
                MInf.x += 1.25f;
            }

            if (gameObject.name == "Karta (78)" || gameObject.name == "Karta (74)" || gameObject.name == "Karta (70)")
            {
                gameObject.transform.position = new Vector3(MInf.x, 5.7f, MInf.z);
                MInf.z += 1.7f;
            }

            if (gameObject.name == "Karta (70)")
            {
                MInf.ready = false;
            }

            if (MInf.name >= 70)
            {
                StartCoroutine(Change());
            }
            MInf.CardAmount--;
            MInf.name--;
        }
    }

    IEnumerator Change()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            yield return new WaitForSeconds(1.0f);

            r = Random.Range(0, 80);
            while (MInf.used.Contains(r))
            {
                r = Random.Range(0, 80);
            }
            MInf.used.Add(r);

            photonView.RPC("Unfolding", RpcTarget.All, r);
        }
    }

    [PunRPC]
    public void Unfolding(int c)
    {
        deck.SetActive(true);
        real = GameObject.Find(MInf.names[c]);
        real.transform.position = gameObject.transform.position;
        p = real.transform.position.x;

        MInf.startGeneralT = true;
        gameObject.SetActive(false);

        for (int i = 0; i < 4; i++)
        {
            if (p == x[i])
            {
                real.tag = "row" + (i + 1).ToString();
            }
        }
    }
}