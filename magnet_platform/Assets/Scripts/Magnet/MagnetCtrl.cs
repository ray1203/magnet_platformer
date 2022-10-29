using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MagnetCtrl : MonoBehaviour
{
    //'n': N±Ø
    //'s': S±Ø
    public char magnetism;
    public float magnetPower = 1.0f;
    public Vector2 power = new Vector2(0, 0);
    private Rigidbody2D rb2D;
    private const float k = 1.0f;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float newX = power.x * k;
        newX *= Time.deltaTime;
        float newY = power.y * k;
        newY *= Time.deltaTime;
        rb2D.AddForce(new Vector2(newX, newY),ForceMode2D.Force);
        //this.transform.position = new Vector2(newX*Time.deltaTime,newY*Time.deltaTime);
    }


}
