using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class TitleManager : MonoBehaviour
{
    public GameObject TextBox;
    private TextMeshProUGUI m_TypingText;
    private string m_Message;
    public float m_Speed = 0.07f;
    private Coroutine coroutine;
    private void Start()
    {
        m_TypingText = TextBox.GetComponent<TextMeshProUGUI>();
        Write(m_TypingText.text, 170, 0.5f);
    }

    public void SelectStage()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Write(string text, float size, float term)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
        m_TypingText.fontSize = size;
        m_Message = text;
        coroutine = StartCoroutine(Typing(m_TypingText, m_Message, m_Speed, term));
    }

    IEnumerator Typing(TextMeshProUGUI typingText, string message, float speed, float term)
    {
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }
        /*yield return new WaitForSeconds(term);
        for (int i = message.Length; i >= 0; i--)
        {
            typingText.text = message.Substring(0, i);
            yield return new WaitForSeconds(0.2f * speed);
        }*/
    }
}
