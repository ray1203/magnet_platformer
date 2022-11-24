using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    public float fadeSpeed = 0.5f;
    private Image image;
    int flag = 0;
    float a = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        FadeIn();
        StageManager.instance.stageChanging = false;
    }

    // Update is called once per frame
    void Update()
    {
        //FadeIn
        if (flag == 0)
        {
            a-=Time.deltaTime* fadeSpeed;
            if (a <= 0.0f)
            {
                flag = -1;
                a = 0.0f;
            }
            image.color = new Color(0, 0, 0, a);
        }
        //FadeOut
        else if (flag == 1)
        {
            a += Time.deltaTime* fadeSpeed;
            if (a >= 1.0f)
            {
                flag = -1;
                a = 1.0f;
                if (StageManager.instance.currentStage == -1|| 
                    !StageManager.instance.MoveStage(StageManager.instance.currentStage + 1)) 
                    SceneManager.LoadScene("StageSelect");
            }
            image.color = new Color(0, 0, 0, a);
        }
    }
    public void FadeIn()
    {
        a = 1.0f;
        flag = 0;
    }
    public void FadeOut()
    {
        a = 0.0f;
        flag = 1;
        GameManager.instance.playerMove.StopMovement();
    }
}
