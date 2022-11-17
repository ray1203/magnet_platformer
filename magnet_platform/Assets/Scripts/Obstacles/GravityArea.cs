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
            rigid.mass *= amount;
            if(collision.CompareTag("Player"))
                GameManager.instance.playerMove.MultiplyJumpPower(amount);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigid))
        {
            rigid.gravityScale /= amount;
            rigid.mass /= amount;
            if (collision.CompareTag("Player"))
                GameManager.instance.playerMove.MultiplyJumpPower(1.0f/amount);
        }
    }
}
