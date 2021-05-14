using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerMove : MonoBehaviour
{
    public bool bCanMove = true;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private bool isGround;
    public bool wallChk;
    Rigidbody2D rigid;
    [SerializeField]
    private Transform bottomChk;
    [SerializeField]
    private float movespeed=10,bottomchkDistance=0.1f,jumpPower,velocityY,coolTime=0f,bCanMoveTime=0f,inputX;
    [SerializeField]
    private Transform attackPos;
    [SerializeField]
    private Vector2 boxsize;
    void Start()
    {
        animator=GetComponent<Animator>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(coolTime>0)
            coolTime-=Time.deltaTime;
        if(bCanMoveTime>0)
            bCanMoveTime-=Time.deltaTime;
        velocityY=rigid.velocity.y;
        animator.SetFloat("velocityY",velocityY);
        Move();
        BottomChk();
        if(Input.GetMouseButtonDown(0)){
            if(!EventSystem.current.IsPointerOverGameObject()&&coolTime<=0f){
                animator.SetTrigger("attack");
                coolTime=0.5f;
                bCanMoveTime=0.5f;
            }
        }
    }
    void BottomChk(){
        Debug.DrawRay(bottomChk.position, Vector3.down * bottomchkDistance, new Color(0, 1, 0));
		isGround = Physics2D.Raycast(bottomChk.position,Vector3.down * bottomchkDistance, bottomchkDistance);
        animator.SetBool("isground",isGround);
    }
    void Move(){
        if (bCanMove == false)
            return;
        

        inputX = Input.GetAxis("Horizontal");
        if(Input.GetAxisRaw("Jump") != 0){
            if(isGround&&velocityY<=0){
                rigid.velocity=new Vector2(rigid.velocity.x,1f*jumpPower);
                animator.SetTrigger("jump");
            }
        }
        if(inputX!=0){
            transform.rotation=new Quaternion(0f,(inputX>0)?0f:180f,0f,0f);
            animator.SetBool("run",true);
        }else animator.SetBool("run",false);
        // if (bCanMoveTime > 0f){
        //     return;
        // }
        if(!wallChk)
            rigid.velocity=new Vector2(movespeed * inputX,rigid.velocity.y);
        else rigid.velocity=new Vector2(0f,rigid.velocity.y);
        // if(wallChk[0]){
        // }
    }
    void Attack(){
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(attackPos.position, boxsize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    if (collider.tag == "Enemy")
                    {
                        Debug.Log("hit!");
                    }
                }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attackPos.position, boxsize);
    }
}
