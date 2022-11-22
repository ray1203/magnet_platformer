using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    Rigidbody2D rigid;
    LineRenderer laser;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        laser = GetComponentInChildren<LineRenderer>();
        laser.positionCount = 2;
        laser.startColor = Color.red;
        laser.endColor = Color.red;
        laser.startWidth = 0.1f;
        laser.endWidth = 0.1f;
        
    }
    Vector2 Rotate(Vector2 pos, float rad)
    {
        float sin = Mathf.Sin(rad);
        float cos = Mathf.Cos(rad);
        return new Vector2(pos.x * cos - pos.y * sin, pos.y * cos + pos.x * sin);
    }
    // Update is called once per frame
    void Update()
    {
        dir = Rotate(Vector2.right, transform.eulerAngles.z / 180.0f * Mathf.PI).normalized;
        Debug.Log(dir);
        RaycastHit2D rayHit = Physics2D.Raycast(laser.transform.position, dir, 100f, LayerMask.GetMask("Platform"));
        RaycastHit2D rayHitP = Physics2D.Raycast(laser.transform.position, dir, 100f, LayerMask.GetMask("Player"));
        if (!rayHit&&rayHitP||rayHit&&rayHitP&&rayHitP.distance < rayHit.distance) GameManager.instance.GameOver();
        if (rayHit)
        {
            
            //Debug.Log(rayHit.transform.name + " " + rayHit.transform.gameObject.layer);
            laser.SetPosition(0, laser.transform.position);
            laser.SetPosition(1, laser.transform.position+dir*rayHit.distance);
            
        }
        else
        {
            laser.SetPosition(0, laser.transform.position);
            laser.SetPosition(1, laser.transform.position + dir * 100);

        }
    }
}
