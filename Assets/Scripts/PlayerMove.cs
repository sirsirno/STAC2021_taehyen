using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private bool isGround;
    Rigidbody2D rigid;
    [SerializeField]
    private Transform bottomChk;
    [SerializeField]
    private float movespeed=10,bottomchkDistance=0.1f,jumpPower;
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        BottomChk();
    }
    void BottomChk(){
        Debug.DrawRay(bottomChk.position, Vector3.down * bottomchkDistance, new Color(0, 1, 0));
		isGround = Physics2D.Raycast(bottomChk.position,Vector3.down * bottomchkDistance, 1);
    }
    void Move(){
        float inputX = Input.GetAxis("Horizontal");
        if(Input.GetAxisRaw("Jump") != 0){
            if(isGround){
                rigid.velocity=Vector2.up*jumpPower;
            }
        }
        if(inputX!=0)
            transform.rotation=new Quaternion(0f,(inputX>0)?0f:180f,0f,0f);
        rigid.velocity=new Vector3(movespeed * inputX,rigid.velocity.y,0f);
    }
}
