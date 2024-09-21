using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            
            PlayerController pc=collision.gameObject.GetComponent<PlayerController>();
            pc.PickKey();
            Destroy(gameObject);
        }
    }
}
