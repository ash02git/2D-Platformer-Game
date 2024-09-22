using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            gameObject.GetComponent<Animator>().SetBool("collected", true);
            PlayerController pc=collision.gameObject.GetComponent<PlayerController>();
            pc.PickKey();
            DestroyKey();
        }
    }
    IEnumerator DestroyKey()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
