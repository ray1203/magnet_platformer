using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGate : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startPos;
    public Vector3 endPos;
    private Vector3 desPos;
    public float speed;
    public bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        desPos = startPos;
    }
    void FixedUpdate()
    {
        if (open)
            desPos = endPos;
        else
            desPos = startPos;
        transform.position = Vector2.MoveTowards(transform.position, desPos, Time.deltaTime * speed);
    }
}
