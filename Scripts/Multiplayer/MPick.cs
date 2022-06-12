using UnityEngine;
using Photon.Pun;

public class MPick : MonoBehaviourPun
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
        if (MInf.wrong == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = card;
            i = 1;
        }
    }

    private void OnMouseDown()
    {
        if(MInf.MMine == 0)
        {
            photonView.RPC("SecondPicker", RpcTarget.Others);
            photonView.RPC("PPick", RpcTarget.All, MInf.MMine);
        }
    }

    [PunRPC]
    public void SecondPicker()
    {
        MInf.MMine = 1;
    }

    [PunRPC]
    public void PPick(int mine)
    {
        if (!ResumeMMenu.GameIsPaused)
        {
            if (i == 1)
            {
                MInf.startTimer = true;
                MInf.wrong = false;
                i++;
            }
            if (MInf.MMine == 0)
            {
                string CardName = gameObject.name;

                if (MInf.reset_T)
                {
                    c = 0;
                    MInf.t = 1;
                    MInf.reset_T = false;
                }

                if (c == 1)
                {
                    photonView.RPC("CardVisiable", RpcTarget.Others, CardName);
                    gameObject.tag = rememberTag;
                    gameObject.GetComponent<SpriteRenderer>().sprite = card;
                    if (MInf.t > 1)
                    {
                        MInf.t--;
                    }
                    c = 0;
                }
                else if (MInf.t < 4 && !MInf.IsAnyAction)
                {
                    rememberTag = gameObject.tag;
                    gameObject.tag = "picked";
                    photonView.RPC("BackVisiable", RpcTarget.Others, CardName);
                    GetComponent<SpriteRenderer>().sprite = back;
                    c++;
                    MInf.t++;
                }
            }
            else if (MInf.MMine == 1)
            {
                return;
            }
        }
    }

    [PunRPC]
    public void BackVisiable(string CardName)
    {
        GameObject mcard = GameObject.Find(CardName);
        mcard.GetComponent<SpriteRenderer>().sprite = back;
    }
    [PunRPC]
    public void CardVisiable(string CardName)
    {
        GameObject mcard = GameObject.Find(CardName);
        mcard.GetComponent<SpriteRenderer>().sprite = card;
    }
}