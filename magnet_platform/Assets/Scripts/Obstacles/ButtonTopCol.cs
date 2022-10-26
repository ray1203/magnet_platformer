using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTopCol : MonoBehaviour
{
    public bool pushing;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="ButtonObj"||collision.isTrigger) return;
        pushing = true;

        Debug.Log(collision.ToString());
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ButtonObj" || collision.isTrigger) return;
        pushing = false;
    }
}
