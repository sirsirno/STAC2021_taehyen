using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float speed;
    [SerializeField] float jumpPower;

    bool isJumped = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            if (rigid.velocity.x > 5)
                return;

            rigid.AddForce(Vector2.right * speed);
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (rigid.velocity.x < -5)
                return;

            rigid.AddForce(Vector2.left * speed);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isJumped)
        {
            isJumped = true;
            rigid.AddForce(Vector2.up * jumpPower);
            Invoke("CanJump", 3);
        }
    }

    private void CanJump()
    {
        isJumped = false;
    }
}
