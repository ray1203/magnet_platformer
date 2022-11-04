using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCtrl : MonoBehaviour
{
    [SerializeField]
    private bool followPlayer = false;
    [SerializeField]
    Queue<Vector2> followRoot = new Queue<Vector2>();
    float t = 0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!followPlayer && !GameManager.instance.keys.Contains(this))
                GameManager.instance.keys.Add(this);
            followPlayer = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        followRoot.Enqueue(GameManager.instance.player.transform.position);
        if (t > 0.7f)
        {
            Vector2 nextPos = followRoot.Dequeue();
            if (followPlayer)
                transform.position = new Vector2(nextPos.x, nextPos.y + 1f) ;
                    //Vector2.MoveTowards(transform.position, nextPos, 1f);
        }
        t += Time.deltaTime;
    }
}
