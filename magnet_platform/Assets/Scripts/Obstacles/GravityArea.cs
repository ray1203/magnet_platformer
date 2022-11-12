using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityArea : MonoBehaviour
{
    public float amount = 0.3f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigid)){
            rigid.gravityScale *= amount;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigid))
        {
            rigid.gravityScale /= amount;
        }
    }
}