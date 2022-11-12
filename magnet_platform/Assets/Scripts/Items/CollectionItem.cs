using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionItem : MonoBehaviour
{
    Animator anim;
    private bool flag = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& !flag)
        {
            flag = true;
            GameManager.instance.collectionCount++;
            anim.SetTrigger("collected");
        }
    }
    public void OnAnimEnd() {
        Destroy(gameObject);
    }
}
