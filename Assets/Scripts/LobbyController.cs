using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    private void Start()
    {
        startButton.onClick.AddListener(ClickedStart);
        quitButton.onClick.AddListener(ClickedQuit);
    }

    private void ClickedStart()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        //SceneManager.LoadScene(1);
    }
    private void ClickedQuit()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Application.Quit();
    }
}
