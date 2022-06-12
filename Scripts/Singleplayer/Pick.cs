using UnityEngine;

public class Pick : MonoBehaviour
{
    public Sprite back;
    private Sprite card;
    public static int i = 1;
    private int c = 0;

    private string rememberTag;

    private void Start()
    {
        card = gameObject.GetComponent<SpriteRenderer>().sprite;
    }
    private void Update()
    {
        if (Inf.wrong == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = card;
            i = 1;
        }
    }

    private void OnMouseDown()
    {
        if (!ResumeMenu.GameIsPaused)
        {
            if (i == 1)
            {
                Inf.startTimer = true;
                Inf.wrong = false;
                i++;
            }

            if (Inf.reset_T)
            {
                c = 0;
                Inf.t = 1;
                Inf.reset_T = false;
            }


            if (c == 1)
            {
                gameObject.tag = rememberTag;
                gameObject.GetComponent<SpriteRenderer>().sprite = card;
                if (Inf.t > 1)
                {
                    Inf.t--;
                }
                c = 0;
            }

            else if (Inf.t < 4 && !Inf.IsAnyAction)
            {
                rememberTag = gameObject.tag;
                gameObject.tag = "picked";
                GetComponent<SpriteRenderer>().sprite = back;
                c++;
                Inf.t++;
            }
        }
    }
}