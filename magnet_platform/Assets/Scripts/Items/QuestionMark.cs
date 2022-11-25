using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMark : MonoBehaviour
{
    public CanvasManager canvasManager;
    public string text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvasManager.Write(text, 28, 3f);
            Destroy(this.gameObject);
        }
    }
}
