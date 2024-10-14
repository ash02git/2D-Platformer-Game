using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;
    public Button exitButton;

    private void Start()
    {
        restartButton.onClick.AddListener(RestartLevel);
        exitButton.onClick.AddListener(BackToLobby);
    }
    public void PlayerDied()
    {
       gameObject.SetActive(true);
    }
    void RestartLevel()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void BackToLobby()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }
}
