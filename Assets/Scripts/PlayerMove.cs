using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private bool isGround;
    Rigidbody2D rigid;
    [SerializeField]
    private Transform bottomChk;
    [SerializeField]
    private float movespeed=10,bottomchkDistance=0.1f,jumpPower,velocityY;
    void Start()
    {
        animator=GetComponent<Animator>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        velocityY=rigid.velocity.y;
        animator.SetFloat("velocityY",velocityY);
        Move();
        BottomChk();
    }
    void BottomChk(){
        Debug.DrawRay(bottomChk.position, Vector3.down * bottomchkDistance, new Color(0, 1, 0));
		isGround = Physics2D.Raycast(bottomChk.position,Vector3.down * bottomchkDistance, bottomchkDistance);
        animator.SetBool("isground",isGround);
    }
    void Move(){
        float inputX = Input.GetAxis("Horizontal");
        if(Input.GetAxisRaw("Jump") != 0){
            if(isGround&&velocityY<=0){
                rigid.velocity=Vector2.up*jumpPower;
                animator.SetTrigger("jump");
            }
        }
        if(inputX!=0){
            transform.rotation=new Quaternion(0f,(inputX>0)?0f:180f,0f,0f);
            animator.SetBool("run",true);
        }else animator.SetBool("run",false);
        rigid.velocity=new Vector3(movespeed * inputX,rigid.velocity.y,0f);
    }
}
