using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private string RUN = "Run";

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sr;

    public float moveX;
    public float speed = 4f;
    private float jumpForce = 7f;

    public bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        keyboardMovement();
        playAnim();
    }

    void keyboardMovement()
    {
        moveX = Input.GetAxis("Horizontal");

        if(moveX >= 0.2f || moveX <= -0.2f)
            transform.position += new Vector3(moveX, 0f, 0f) * speed * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && isGround)
            jump();
    }

    void jump()
    {
        isGround = false;
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        anim.SetBool("Jump", true);
        //Invoke("stopJump", 1f);
         
    }

    //void stopJump()
    //{
    //    anim.SetBool("Jump", false);
    //}

    void playAnim()
    {
        if (moveX >= 0.1f) {
            anim.SetBool(RUN, true);
            sr.flipX = false;
        }
        else if (moveX <= -0.1f)
        {
            anim.SetBool(RUN, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(RUN, false);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            isGround = true;
            anim.SetBool("Jump", false);
        }
    }
}
