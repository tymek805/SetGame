using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private InputField nameInputFiled = null;
    [SerializeField] private Button SubmitButton = null;
    [SerializeField] private GameObject background = null;
    [SerializeField] private GameObject buttons = null;
    [SerializeField] private GameObject nickinput = null;
    public GameObject vol;

    private const string nickPref = "PlayerName";

    private void Start()
    {
        SetUpInputField();
    }

    private void SetUpInputField()
    {
        if (!PlayerPrefs.HasKey(nickPref))
        {
            PlayerPrefs.SetInt("Beginner", 1);
            return;
        }
        string defaultName = PlayerPrefs.GetString(nickPref);

        nameInputFiled.text = defaultName;

        SetPlayerName(defaultName);
    }
    public void SetPlayerName(string name)
    {
        SubmitButton.interactable = !string.IsNullOrEmpty(name);
    }
    public void SavePlayerName()
    {
        string playerName = nameInputFiled.text;

        PhotonNetwork.NickName = playerName;

        PlayerPrefs.SetString(nickPref, playerName);

        int test = PlayerPrefs.GetInt("Beginner");
        if(test == 1)
        {
            background.SetActive(true);
            SceneManager.LoadScene("Tutorial");
        }
        else
        {
            vol.SetActive(true);
            buttons.SetActive(true);
            nickinput.SetActive(false);
            background.SetActive(false);
        }
    }
}
