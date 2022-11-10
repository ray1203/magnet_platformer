using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTopCol : MonoBehaviour
{
    public bool pushing;
    [SerializeField]
    private float timer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="ButtonObj"||collision.isTrigger) return;
        pushing = true;
        //collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -1f) * Time.deltaTime);
        timer = 0f;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ButtonObj" || collision.isTrigger) return;
        timer += Time.deltaTime;
    }
    private void Update()
    {
        if (timer > 0.0f)
        {
            timer += Time.deltaTime;
            if (timer >= 0.2f)
            {
                pushing = false;
                timer = 0.0f;
            }
        }
    }
}
