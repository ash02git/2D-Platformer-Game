using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDeathController : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Player Fell to Death");

            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            pc.KillPlayer();

            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
