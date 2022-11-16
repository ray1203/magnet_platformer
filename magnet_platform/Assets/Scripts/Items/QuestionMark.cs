using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMark : MonoBehaviour
{
    public StageText UiDirector;
    public string text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UiDirector.Write(text, 28, 3f);
            Destroy(this.gameObject);
        }
    }
}
