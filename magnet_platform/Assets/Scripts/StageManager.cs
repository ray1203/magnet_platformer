using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public List<int> stages = new List<int>();
    private void Awake()
    {
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
    public void StageClear(int stageNum,int amount=1)
    {
        if (stages[stageNum] < amount) stages[stageNum] = amount;
        SaveData();

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
        return str;
    }
    private void StrToData(string str)
    {
        string[] datas = str.Split(' ');
        for (int i = 0; i < stages.Count; i++)
            stages[i] = int.Parse(datas[i]);
    }
}
