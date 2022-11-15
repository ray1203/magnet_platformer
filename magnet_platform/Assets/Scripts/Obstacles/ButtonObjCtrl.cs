using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObjCtrl : MonoBehaviour
{
    private ButtonTopCol topCol;
    private Transform buttonTop;
    
    public List<GameObject> attachedObjs = new List<GameObject>();
    private List<ButtonData> buttonDatas = new List<ButtonData>();
    private Vector2 topScale;
    // Start is called before the first frame update
    void Start()
    {
        topCol = GetComponentInChildren<ButtonTopCol>();
        buttonTop = gameObject.transform.Find("Top");
        topScale = buttonTop.localScale;
        
        for(int i = 0; i < attachedObjs.Count; i++)
        {
            ButtonData buttonData = new ButtonData();
            buttonData.objSprite = attachedObjs[i].GetComponent<SpriteRenderer>();
            if (attachedObjs[i].TryGetComponent<MagnetCtrl>(out MagnetCtrl magnetCtrl))
            {
                buttonData.setting = ButtonData.ButtonSetting.magnet;
                buttonData.magnetCtrl = magnetCtrl;
                buttonData.magnetism = magnetCtrl.magnetism;
                
            }else if (attachedObjs[i].TryGetComponent<ButtonGate>(out ButtonGate buttonGate))
            {
                buttonData.setting = ButtonData.ButtonSetting.gate;
                buttonData.buttonGate = buttonGate;
            }
            buttonData.SetFunc();
            buttonDatas.Add(buttonData);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (topCol.pushing)
        {
            float newScaleY = buttonTop.localScale.y - Time.deltaTime;
            newScaleY = newScaleY > 0.05f ? newScaleY : 0.05f;
            buttonTop.localScale = new Vector2(topScale.x,newScaleY);
            buttonTop.transform.localPosition = new Vector2(0, 0.25f + newScaleY / 2.0f);
            for(int i=0;i<buttonDatas.Count;i++)
                buttonDatas[i].func(true);
        }
        else
        {
            float newScaleY = buttonTop.localScale.y + Time.deltaTime;
            newScaleY = newScaleY <= topScale.y ? newScaleY : topScale.y;
            buttonTop.localScale = new Vector2(topScale.x, newScaleY);
            buttonTop.transform.localPosition = new Vector2(0, 0.25f + newScaleY / 2.0f);
            for (int i = 0; i < buttonDatas.Count; i++)
                buttonDatas[i].func(false);
        }
    }
    
}
public class ButtonData
{
    public enum ButtonSetting
    {
        magnet,
        gate,
    }
    public ButtonSetting setting;
    public delegate void emptyFunc(bool flag);
    public emptyFunc func;
    public SpriteRenderer objSprite;
    public MagnetCtrl magnetCtrl;
    public char magnetism;
    public ButtonGate buttonGate;
    public void SetFunc()
    {
        if (setting == ButtonSetting.magnet)
        {
            func = delegate (bool flag)
            {
                if (flag)
                {
                    magnetCtrl.magnetism = magnetism;
                    if (magnetCtrl.magnetism == 'n') objSprite.sprite = SpriteManager.instance.magnetN;
                    if (magnetCtrl.magnetism == 's') objSprite.sprite = SpriteManager.instance.magnetS;
                }
                else
                {
                    magnetCtrl.magnetism = ' ';
                    objSprite.sprite = SpriteManager.instance.whiteTile;
                }
            };
        }else if(setting == ButtonSetting.gate)
        {
            func = delegate (bool flag)
            {
                buttonGate.open = flag;
            };
        }
    }
}