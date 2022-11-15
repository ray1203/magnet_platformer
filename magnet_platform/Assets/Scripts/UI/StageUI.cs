using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUI : MonoBehaviour
{
    public Transform stages;
    private int lastStage=-1;
    public Sprite filledStar;
    // Start is called before the first frame update
    void Start()
    {
        LoadStageUI();
    }

    public void LoadStageUI()
    {
        Debug.Log("stageUI load");
        lastStage = -1;
        for (int i = 0; i < stages.childCount; i++)
        {
            if (StageManager.instance.stages[i] == 0)
            {
                if (lastStage == -1) lastStage = i;
                else
                {
                    stages.GetChild(i).GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
                    for(int j = 0; j < 3; j++)
                    {
                        stages.GetChild(i).GetChild(j).GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
                    }
                    stages.GetChild(i).GetChild(3).GetComponent<Text>().color = new Color(0.5f, 0.5f, 0.5f);
                }
            }
            else
            {
                if (StageManager.instance.stages[i] >= 1)stages.GetChild(i).Find("Star1").GetComponent<Image>().sprite = filledStar;
                if (StageManager.instance.stages[i] >= 2)stages.GetChild(i).Find("Star3").GetComponent<Image>().sprite = filledStar;
                if (StageManager.instance.stages[i] >= 3)stages.GetChild(i).Find("Star2").GetComponent<Image>().sprite = filledStar;
            }
        }
    }
}
