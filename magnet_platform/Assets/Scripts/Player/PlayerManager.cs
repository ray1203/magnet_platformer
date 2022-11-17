using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<MagnetCtrl> blocks = new List<MagnetCtrl>();
    public Rigidbody2D rgbd;
    private void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Block"))
            if (collision.transform.TryGetComponent<MagnetCtrl>(out MagnetCtrl block))
                if (!blocks.Contains(block))
                {
                    block.GetComponent<MagnetCtrl>().power = Vector2.zero;
                    blocks.Add(block);
                }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Block"))
            if (collision.transform.TryGetComponent<MagnetCtrl>(out MagnetCtrl block))
                if (blocks.Contains(block))
                    blocks.Remove(block);
    }
}
