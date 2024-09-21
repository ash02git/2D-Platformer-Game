using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        HorizontalAnimation(horizontal);
        

        float vertical = Input.GetAxisRaw("Vertical");
        JumpAnimation(vertical);

        MoveCharacter(horizontal,vertical);//movement - position changing

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", true);
        }
        
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", false);
        }
        
    }
    void HorizontalAnimation(float horizontalValue)
    {
        animator.SetFloat("speed", Mathf.Abs(horizontalValue));
        Vector3 scale = transform.localScale;
        if (horizontalValue < 0)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        else if (horizontalValue > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    void JumpAnimation(float verticalValue)
    {
        if (verticalValue > 0)
        {
            animator.SetBool("jump", true);
        }
        if (verticalValue <= 0)
        {
            animator.SetBool("jump", false);
        }
    }

    void MoveCharacter(float horizontal,float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        if(vertical>0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }
}
