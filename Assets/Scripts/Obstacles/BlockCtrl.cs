using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCtrl : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField]
    private bool flag;
    [SerializeField]
    private bool isGround=false;
    public float drag = 0f;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            flag = true;
        if (collision.transform.CompareTag("Platform"))
            isGround = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            flag = false;
        if (collision.transform.CompareTag("Platform"))
            isGround = false;
    }
    private void FixedUpdate()
    {
        if (flag)
        {
            rigid.AddForce(new Vector2(-GameManager.instance.playerRigid.velocity.x*Time.deltaTime,0), ForceMode2D.Impulse);
        }
        if (isGround)
        {
            Vector2 newVelocity = rigid.velocity;
            if (rigid.velocity.x > 0)
            {
                newVelocity.x -= drag*Time.deltaTime;
                if (newVelocity.x < 0) newVelocity.x = 0;
            }
            else
            {
                newVelocity.x += drag * Time.deltaTime;
                if (newVelocity.x > 0) newVelocity.x = 0;
            }
            rigid.velocity = newVelocity;
        }

    }

}
