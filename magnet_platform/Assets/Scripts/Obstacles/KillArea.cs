using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillArea : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
        if(collision.CompareTag("Block"))
        {
            collision.gameObject.GetComponent<MagnetCtrl>().deleteMagnet();
        }
    }
}
