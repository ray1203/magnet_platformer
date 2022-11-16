using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StageText : MonoBehaviour
{
    public TextMeshProUGUI m_TypingText;
    private string m_Message;
    public float m_Speed = 0.07f;
    
    // Start is called before the first frame update 
    void Start()
    {
        m_Message = m_TypingText.text;
        m_TypingText.outlineWidth = 1;
        m_TypingText.outlineColor = new Color32(255, 255, 255, 255);
        StartCoroutine(Typing(m_TypingText, m_Message, m_Speed));
    }

    IEnumerator Typing(TextMeshProUGUI typingText, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(5 * speed);
        for (int i = message.Length; i >= 0; i--)
        {
            typingText.text = message.Substring(0, i);
            yield return new WaitForSeconds(0.2f * speed);
        }
    }

}
