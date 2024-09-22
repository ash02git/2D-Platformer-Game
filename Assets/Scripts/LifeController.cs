using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public int livesCount;
    public GameObject Player;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void reduceLife()
    {
        livesCount--;
        GameObject toBeDestroyed = transform.GetChild(0).gameObject;
        Destroy(toBeDestroyed);

        if(livesCount == 0)
        {
            Player.GetComponent<PlayerController>().KillPlayer();
        }
    }
}
