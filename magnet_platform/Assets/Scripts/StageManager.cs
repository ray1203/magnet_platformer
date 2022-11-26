using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public bool stageChanging = false;
    public static StageManager instance;
    public List<int> stages = new List<int>();
    private List<string> stageNames = new List<string>() {
    "Stage1-1",
    "ray_stage2",
    "ray_stage1",
    "ray_stage3",
    "ray_stage4",
    };
    public int currentStage = -1;
    private void Awake()
    {
        if (instance == null)
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
        else Destroy(gameObject);
    }
    public void StageClear()
    {
        if (stageChanging) return;
        Debug.Log("stageclear:" + currentStage);
        stageChanging = true;
        GameManager.instance.godMod = true;
        if (currentStage == -1)
        {
            GameManager.instance.fadeEffect.FadeOut();
            //SceneManager.LoadScene("StageSelect");
            return;
        }
        int amount = GameManager.instance.collectionCount+1;
        if (stages[currentStage] < amount) stages[currentStage] = amount;
        SaveData();
        
        GameManager.instance.fadeEffect.FadeOut();
        //if(!MoveStage(currentStage + 1))SceneManager.LoadScene("StageSelect");
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
    public static void _MoveStage(int stageNum)
    {
        StageManager.instance.MoveStage(stageNum);
    }
    public void ClearData()
    {
        for (int i = 0; i < stages.Count; i++) stages[i] = 0;
        SaveData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
