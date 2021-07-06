using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    
    public int speed = 7;//กำหนดความเร็ว
    public int JumpForce = 800;//กระโดด
    public float moveX;
    public bool isGround;//เช็คว่ายืนอยู่บนพื้น
    private Animator anim;//รับ animater controller
    private Rigidbody2D rb;  
    private bool mirrered;
    void Start() { 
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    
    
    void Update() { 
        moveX = Input.GetAxis("Horizontal");//เเนวนอน
        //กระโดด
        if (Input.GetButtonDown("Jump") && isGround==true)
        {
           Jump();
        }
        if (!isGround) 
        {
            anim.SetBool("IsJumping",true);
        }
        //เคลื่อนที่
        if (moveX!=0 && isGround)
        {
            anim.SetBool("IsRunning",true);
        }
        else
        {
            anim.SetBool("IsRunning",false);
        }
        // มุม Mirrored
        if (moveX < 0.0f && mirrered==false)
        {
            FlipPlayer();
        }else if (moveX > 0.0f && mirrered == true)
        {
            FlipPlayer();
        }
        rb.velocity = new Vector2(moveX*speed,gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }

    private void FlipPlayer()
    {
        mirrered = !mirrered;
        Vector2 local = gameObject.transform.localScale;
        local.x *= -1;
        transform.localScale = local;
    }

    void Jump()
    {
    rb.AddForce(Vector2.up*JumpForce);
    isGround = false;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="Ground" || other.gameObject.tag == "Box")
        {
            isGround = true;
            anim.SetBool("IsJumping",false);
        }
        if (other.gameObject.tag=="EndLevel")
        {
            Application.LoadLevel("Home");
        }
    }
}