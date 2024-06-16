using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    private GameObject Canvas;
    private GameObject MenuSet;
    private TextMeshProUGUI m_TypingText;
    private string m_Message;
    public float m_Speed = 0.07f;
    private Coroutine coroutine;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        MenuSet = Canvas.transform.GetChild(1).gameObject;
        m_TypingText = Canvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Write(m_TypingText.text, 36, 0.5f);
        MenuSet.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(MenuOnOff);
        MenuSet.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(Restart);
        MenuSet.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(SelectMenu);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            MenuOnOff();
    }

    public void Write(string text, float size, float term)
    {
        if(coroutine != null)
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
        yield return new WaitForSeconds(term);
        for (int i = message.Length; i >= 0; i--)
        {
            typingText.text = message.Substring(0, i);
            yield return new WaitForSeconds(0.2f * speed);
        }
    }
    public void MenuOnOff()
    {
        if (MenuSet.activeSelf == false)
        {
            MenuSet.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            MenuSet.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Restart()
    {
        GameManager.instance.Restart();
    }

    public void SelectMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StageSelect");
    }
}
