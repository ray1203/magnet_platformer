using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    private Vector3 startPos;
    public Vector3 endPos;
    private Vector3 desPos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        desPos = endPos;
    }
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, desPos, Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, startPos.z);
        if (Vector2.Distance(transform.position, desPos) <= 0.05f)
        {
            if (desPos == endPos) desPos = startPos;
            else desPos = endPos;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player") || collision.transform.CompareTag("Block"))
        {
            collision.transform.SetParent(transform);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("Block"))
        {
            collision.transform.SetParent(null);
        }
    }
}
