using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCtrl : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && GameManager.instance.keys.Count >= 1)
        {
            Destroy(GameManager.instance.keys[0].gameObject);
            GameObject.Destroy(gameObject);
        }
    }
}
