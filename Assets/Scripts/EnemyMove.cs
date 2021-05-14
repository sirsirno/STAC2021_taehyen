using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public bool bCanMove = true;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private bool isGround;
    Rigidbody2D rigid;

    [SerializeField]
    private float movespeed=10,jumpPower,velocityY,distance,stopDistance;
    private GameObject player;
    void Start()
    {
        player = GameManager.Instance.player;
        animator=GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Vector2.Distance(transform.position,player.transform.position)<distance
        &&Vector2.Distance(transform.position,player.transform.position)>stopDistance)
            Move();
    }
    
    void Move(){
        if (bCanMove == false)
            return;

        float inputX = (transform.position.x-player.transform.position.x<0)?1:-1;
        
        if(Input.GetAxisRaw("Jump") != 0){
            if(isGround&&velocityY<=0){
                rigid.velocity=Vector2.up*jumpPower;
            }
        }
        if(inputX!=0){
            transform.rotation=new Quaternion(0f,(inputX>0)?0f:180f,0f,0f);
        }
        rigid.velocity=new Vector3(movespeed * inputX,rigid.velocity.y,0f);
    }
}
