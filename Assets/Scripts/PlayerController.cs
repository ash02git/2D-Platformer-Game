using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x= -Mathf.Abs(scale.x);
        }
        else if(speed > 0)
        {
            scale.x= Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if(vertical>0)
        {
            animator.SetBool("jump",true);
        }
        if(vertical<=0)
        {
            animator.SetBool("jump", false);
        }

        if(Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", true);
        }
        
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", false);
        }
        
    }
}
