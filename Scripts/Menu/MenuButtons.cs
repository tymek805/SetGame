using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject options;

    public void Start()
    {
        options.SetActive(false);
    }

    public void Singleplayer()
    {
        SceneManager.LoadScene("Singleplayer");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
