using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class MStarter : MonoBehaviourPun
{
    [SerializeField] private GameObject start = null;
    [SerializeField] private GameObject confirm = null;
    [SerializeField] private GameObject emptyPref = null;

    [SerializeField] private Light lt = null; 

    [SerializeField] private Slider sChoise = null;
    [SerializeField] private Slider sChange = null;
    [SerializeField] private Text sChoiseText = null;
    [SerializeField] private Text sChangeText = null;

    private float f1 = 1;
    private float f2 = 1;

    private void Start()
    {
        //Ustawia możliwość dostępu do ustawień
        if (PhotonNetwork.IsMasterClient)
        {
            start.GetComponent<BoxCollider>().enabled = true;
            sChange.interactable = true;
            sChoise.interactable = true;
        }
        else
        {
            start.GetComponent<BoxCollider>().enabled = false;
            sChange.interactable = false;
            sChoise.interactable = false;
        }
        sChoiseText.text = (f1 * 5).ToString() + " seconds";
        sChangeText.text = (f2 * 10).ToString() + " seconds";
    }
    private void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            f1 = sChoise.GetComponent<Slider>().value;
            f2 = sChange.GetComponent<Slider>().value;
            float[] floats = { f1, f2 };
            gameObject.GetComponent<PhotonView>().RPC("Sliders", RpcTarget.All, floats);
        }
    }

    private void OnMouseDown()
    {
        float[] floats = { f1, f2 };
        photonView.RPC("StartGame", RpcTarget.All, floats);
    }

    [PunRPC]
    public void StartGame(float[] tm)
    {
        tm[0] = sChoise.GetComponent<Slider>().value;
        tm[1] = sChange.GetComponent<Slider>().value;

        MTimer.ChoisingTime = tm[0] * 5;
        MGeneralTimer.changingTime = tm[1] * 10;
        MGeneralTimer.TimeToChange = MGeneralTimer.changingTime;
        MTimer.TimeForChoise = MTimer.ChoisingTime;
        emptyPref.SetActive(false);
        StartCoroutine(Lights());
    }

    IEnumerator Lights()
    {
        lt.intensity = 2;
        yield return new WaitForSeconds(0.25f);
        lt.intensity = 1;
        emptyPref.SetActive(false);
        start.SetActive(false);
        confirm.SetActive(true);
        MInf.ready = true;
        StopCoroutine(Lights());
    }

    [PunRPC]
    public void Sliders(float[] value)
    {
        sChoise.value = value[0];
        sChange.value = value[1];
        sChoiseText.text = (value[0] * 5).ToString() + " seconds";
        sChangeText.text = (value[1] * 10).ToString() + " seconds";
    }
}