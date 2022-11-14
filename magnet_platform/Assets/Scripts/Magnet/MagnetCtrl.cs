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
        if (magnetism != 'n' && magnetism != 's') magnetism = ' ';
        if (magnetism == 'N') magnetism = 'n';
        if (magnetism == 'S') magnetism = 's';

    }
    void FixedUpdate()
    {
        float newX = power.x * k;
        newX *= Time.deltaTime;
        float newY = power.y * k;
        newY *= Time.deltaTime;
        rb2D.AddForce(new Vector2(newX, newY),ForceMode2D.Force);
        //this.transform.position = new Vector2(newX*Time.deltaTime,newY*Time.deltaTime);
    }

    public void deleteMagnet()
    {
        
        List<MagnetCtrl> magnetCtrls = GameObject.Find("GameManager").GetComponent<MagnetManager>().magnetCtrls;
        for (int i = magnetCtrls.Count - 1; i >= 0; i--)
        {
            
            if (this.gameObject == magnetCtrls[i].gameObject)
                magnetCtrls.Remove(magnetCtrls[i]);
        }
        Destroy(gameObject);
    }
    
}

