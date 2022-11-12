using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public List<int> stages = new List<int>();
    private List<string> stageNames = new List<string>() {
    "ray_stage1",
    "",
    "",
    "",
    "",
    };
    public int currentStage = -1;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        for (int i = 0; i < 5; i++) stages.Add(0);
        instance = this;
        if (!PlayerPrefs.HasKey("stage"))
        {
            SaveData();
        }
        else
        {
            StrToData(PlayerPrefs.GetString("stage"));
        }
    }
    private void Start()
    {
        
    }
    public void StageClear()
    {
        int amount = GameManager.instance.collectionCount+1;
        if (stages[currentStage] < amount) stages[currentStage] = amount;
        SaveData();
        if(!MoveStage(currentStage + 1))SceneManager.LoadScene("StageSelect");
    }
    private void SaveData()
    {
        PlayerPrefs.SetString("stage", DataToStr());
        PlayerPrefs.Save();
    }
    private string DataToStr()
    {
        string str = "";
        for (int i = 0; i < stages.Count; i++)
            str += stages[i].ToString() + " ";
        Debug.Log("stage:"+str);
        return str;
    }
    private void StrToData(string str)
    {
        Debug.Log("stage:" + str);
        string[] datas = str.Split(' ');
        for (int i = 0; i < stages.Count; i++)
            stages[i] = int.Parse(datas[i]);
    }
    
    public bool MoveStage(int stageNum)
    {
        Debug.Log(stageNum);
        if (stageNum < 0 || stageNum >= stages.Count || stageNames[stageNum] == "") return false;
        Debug.Log(stageNames[stageNum]);
        SceneManager.LoadScene(stageNames[stageNum]);
        currentStage = stageNum;
        return true;
    }
    public void _MoveStage(int stageNum)
    {
        MoveStage(stageNum);
    }
    public void ClearData()
    {
        for (int i = 0; i < stages.Count; i++) stages[i] = 0;
        SaveData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
