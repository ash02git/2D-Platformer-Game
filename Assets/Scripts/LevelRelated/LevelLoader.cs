using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string levelName;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(buttonClicked);
    }

    private void buttonClicked()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Level locked, cant play this level");
                break;

            case LevelStatus.Unlocked:
                Debug.Log("Level unlocked, can play this level");
                SceneManager.LoadScene(levelName);
                break;

            case LevelStatus.Complete:
                Debug.Log("Level already completed, can play this level");
                SceneManager.LoadScene(levelName);
                break;
        }

        
    }
}
