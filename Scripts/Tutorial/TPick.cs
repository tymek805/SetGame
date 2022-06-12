using UnityEngine;

public class TPick : MonoBehaviour
{
    public Sprite back;
    private Sprite card;
    public static int i = 1;
    private int c = 0;
    private bool inresetT = false;

    private string rememberTag;

    private void Start()
    {
        card = gameObject.GetComponent<SpriteRenderer>().sprite;
    }
    private void Update()
    {
        if (TInf.wrong == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = card;
            i = 1;
        }

        if(TInf.reset_T == true)
        {
            for (int f = 0; f < 3; f++)
            {
                if (gameObject.name == TInf.p_cards[f])
                {
                    inresetT = true;
                    TInf.p_cards[f] = "";
                }
            }
        }
    }

    public void OnMouseDown()
    {
        if(inresetT == true)
        {
            c = 0;
            inresetT = false;
        }

        if (!TResumeMenu.GameIsPaused)
        {
            if (i == 1)
            {
                TInf.wrong = false;
                i++;
            }

            if (c == 1)
            {
                gameObject.tag = rememberTag;
                gameObject.GetComponent<SpriteRenderer>().sprite = card;
                if (TInf.t > 1)
                {
                    TInf.t--;
                }
                c = 0;
            }

            else if (TInf.t < 4)
            {
                gameObject.GetComponent<Animator>().SetBool("End", true);
                TBot.starter = false;
                TBot.time = TBot.timeToChange;
                rememberTag = gameObject.tag;
                gameObject.tag = "picked";
                GetComponent<SpriteRenderer>().sprite = back;
                c = 1;
                TInf.t++;
            }
        }
    }
}