using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndController : MonoBehaviour
{
    public string nextScene;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("LEvel completed");
            LevelManager.Instance.MarkCurrentLevelCompleted();
            SceneManager.LoadScene(nextScene);
            SoundManager.Instance.Play(Sounds.LevelEnd);
        }
    }
}
