using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCtrl : MonoBehaviour
{
    private Rigidbody2D rigid;
    private bool flag;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            flag = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            flag = false;
    }
    private void FixedUpdate()
    {
        if (flag)
        {
            rigid.AddForce(new Vector2(-GameManager.instance.playerRigid.velocity.x*2*Time.deltaTime,0), ForceMode2D.Impulse);
        }

    }
}
