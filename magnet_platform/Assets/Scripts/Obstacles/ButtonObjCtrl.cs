using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObjCtrl : MonoBehaviour
{
    private ButtonTopCol topCol;
    private Transform buttonTop;
    public enum ButtonSetting
    {
        magnet,
        gate,

    }
    public ButtonSetting setting;
    public GameObject attachedObj;
    private Vector2 topScale;
    private delegate void emptyFunc(bool flag);
    private emptyFunc func;
    private SpriteRenderer objSprite;

    private MagnetCtrl magnetCtrl;
    private char magnetism;

    private ButtonGate buttonGate;
    // Start is called before the first frame update
    void Start()
    {
        topCol = GetComponentInChildren<ButtonTopCol>();
        buttonTop = gameObject.transform.Find("Top");
        topScale = buttonTop.localScale;
        objSprite = attachedObj.GetComponent<SpriteRenderer>();
        if(setting == ButtonSetting.magnet)
        {
            attachedObj.TryGetComponent<MagnetCtrl>(out magnetCtrl);
            magnetism = magnetCtrl.magnetism;
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
        }else if (setting == ButtonSetting.gate)
        {
            attachedObj.TryGetComponent<ButtonGate>(out buttonGate);
            func = delegate (bool flag)
            {
                buttonGate.open = flag;
            };
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
            func(true);
        }
        else
        {
            float newScaleY = buttonTop.localScale.y + Time.deltaTime;
            newScaleY = newScaleY <= topScale.y ? newScaleY : topScale.y;
            buttonTop.localScale = new Vector2(topScale.x, newScaleY);
            buttonTop.transform.localPosition = new Vector2(0, 0.25f + newScaleY / 2.0f);

            func(false);
        }
    }
    
}
