
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public string Level1;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
        if(GetLevelStatus("Level1")==LevelStatus.Locked)
        {
            SetLevelStatus(Level1, LevelStatus.Unlocked);
        }
    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus=(LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }
    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }

    public void MarkCurrentLevelCompleted()
    {
        Scene scene = SceneManager.GetActiveScene();
        SetLevelStatus(scene.name, LevelStatus.Complete);

        int nextSceneIndex = scene.buildIndex + 1;
        Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
        SetLevelStatus(nextScene.name, LevelStatus.Unlocked);
    }
}
