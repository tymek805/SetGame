using UnityEngine;
using UnityEngine.SceneManagement;

public class TResumeMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public Sprite back;

    public GameObject pauseMenu;
    private GameObject[] cards = new GameObject[12];

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        TInf.wrong = true;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        TInf.wrong = false;
        for(int i = 1; i < 5;i++)
        {
            cards = GameObject.FindGameObjectsWithTag("row" + i.ToString());
            for(int x = 0; x < 3; x++)
            {
                cards[x].GetComponent<SpriteRenderer>().sprite = back;
            }
        }

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Menu()
    {
        FindObjectOfType<TEnd>().Restart();

        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
