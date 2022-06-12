using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Starter : MonoBehaviour
{
    public Slider sChoise;
    public Slider sChange;
    public Text sChoiseText;
    public Text sChangeText;

    public GameObject NoobText;

    public static float f1 = 1;
    public static float f2 = 1;

    public GameObject start;
    public GameObject confirm;
    public GameObject empty; //emptyPref
    public GameObject resumeMenu;

    public Light lt;

    private void Start()
    {
        sChoiseText.text = (f1 * 5).ToString() + " seconds";
        sChangeText.text = (f2 * 10).ToString() + " seconds";

        int test = PlayerPrefs.GetInt("Beginner");
        if(test == 1)
        {
            NoobText.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        NoobText.SetActive(false);

        f1 = sChoise.GetComponent<Slider>().value;
        f2 = sChange.GetComponent<Slider>().value;

        Timer.ChoisingTime = f1 * 5;
        GeneralTimer.changingTime = f2 * 10;

        GeneralTimer.TimeToChange = GeneralTimer.changingTime;
        Timer.TimeForChoise = Timer.ChoisingTime;

        empty.SetActive(false);

        StartCoroutine(Lights());
    }

    public void Update()
    {
        f1 = sChoise.GetComponent<Slider>().value;
        f2 = sChange.GetComponent<Slider>().value;

        sChoiseText.text = (f1 * 5).ToString() + " seconds";
        sChangeText.text = (f2 * 10).ToString() + " seconds";
    }

    IEnumerator Lights()
    {
        lt.intensity = 2;
        yield return new WaitForSeconds(0.25f);
        lt.intensity = 1;
        Inf.ready = true;
        confirm.transform.position = start.transform.position;
        start.SetActive(false);
        confirm.SetActive(true);
        empty.SetActive(false);
        StopCoroutine(Lights());
    }
}