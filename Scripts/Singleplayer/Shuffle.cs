using System.Collections;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    [SerializeField] private GameObject deck;
    private GameObject real;

    private int i = 0;
    private int r;

    private float[] x = { -2f, -0.75f, 0.5f, 1.75f };
    private float p;

    void Start()
    {
        gameObject.SetActive(true);

        while (i < 81)
        {
            gameObject.transform.position = new Vector3(6, Inf.position, 1);
            Inf.position += 0.00006f;
            i++;
        }
    }

    public void Update()
    {
        if (gameObject.name == "Karta (" + Inf.name + ")" && Inf.ready == true)
        {
            if (Inf.name > 78)
            {
                gameObject.transform.position = new Vector3(Inf.x, 5.7f, Inf.z);
                Inf.x += 1.25f;
            }

            if (Inf.name < 78 && Inf.name > 74)
            {
                gameObject.transform.position = new Vector3(Inf.x, 5.7f, Inf.z);
                Inf.x -= 1.25f;
            }

            if (Inf.name < 74 && Inf.name > 70)
            {
                gameObject.transform.position = new Vector3(Inf.x, 5.7f, Inf.z);
                Inf.x += 1.25f;
            }

            if (gameObject.name == "Karta (78)" || gameObject.name == "Karta (74)" || gameObject.name == "Karta (70)")
            {
                gameObject.transform.position = new Vector3(Inf.x, 5.7f, Inf.z);
                Inf.z += 1.7f;
            }

            if (gameObject.name == "Karta (70)")
            {
                Inf.ready = false;
            }

            if (Inf.name >= 70)
            {
                StartCoroutine(Change());
            }
            Inf.CardAmount--;
            Inf.name--;
        }
    }

    IEnumerator Change()
    {
        yield return new WaitForSeconds(1.0f);

        Inf.startGeneralT = true;

        r = Random.Range(0, 80);

        while (Inf.used.Contains(r))
        {
            r = Random.Range(0, 80);
        }

        if (!Inf.used.Contains(r))
        {
            deck.SetActive(true);
            real = GameObject.Find(Inf.names[r]);
            real.transform.position = gameObject.transform.position;
            p = real.transform.position.x;
            gameObject.SetActive(false);
        }

        for (int i = 0; i < 4; i++)
        {
            if(p == x[i])
            {
                real.tag = "row" + (i + 1).ToString();
            }
        }

        Inf.used.Add(r);
    }
}