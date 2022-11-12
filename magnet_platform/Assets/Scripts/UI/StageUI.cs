using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUI : MonoBehaviour
{
    public Transform stages;
    private int lastStage=-1;
    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i < stages.childCount; i++)
        {
            if (StageManager.instance.stages[i] == 0)
            {
                Debug.Log("Stage" + i);
                if (lastStage == -1) lastStage = i;
                else stages.GetChild(i).GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
