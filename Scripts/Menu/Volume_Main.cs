using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume_Main : MonoBehaviour
{
    public GameObject buttons;
    public GameObject slider;
    private static bool show = false;
    public void OnMouseDown()
    {
        buttons.SetActive(show);
        slider.SetActive(!show);
        show = !show;
    }
}
