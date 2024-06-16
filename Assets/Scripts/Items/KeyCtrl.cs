using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCtrl : MonoBehaviour
{
    [SerializeField]
    private bool followPlayer = false;
    private float distance = 1f;
    private float speed = 2f;
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
        if(followPlayer)
            if (Vector2.Distance(GameManager.instance.player.transform.position, transform.position) >= distance)
                transform.position= Vector2.Lerp(transform.position, GameManager.instance.player.transform.position, speed*Time.deltaTime);
    }
}
