using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMagnet : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = this.GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
        rigid = this.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * rigid.velocity.x*(-30.0f)));
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            boxCollider2D.enabled = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            boxCollider2D.enabled = false;

    }

}
