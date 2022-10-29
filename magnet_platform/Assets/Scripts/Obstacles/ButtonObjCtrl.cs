using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObjCtrl : MonoBehaviour
{
    private ButtonTopCol topCol;
    private Transform buttonTop;
    //작동 시 시행할 행동
    public MagnetCtrl attachedMagnet;
    public SpriteRenderer magnetSprite;
    public int magnetPower = 200;
    private Vector2 topScale;
    // Start is called before the first frame update
    void Start()
    {
        topCol = GetComponentInChildren<ButtonTopCol>();
        buttonTop = gameObject.transform.Find("Top");
        topScale = buttonTop.localScale;
        magnetSprite = attachedMagnet.GetComponent<SpriteRenderer>();
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
            attachedMagnet.magnetPower = magnetPower;
            if (attachedMagnet.magnetism=='s') magnetSprite.color = Color.blue;
            else if(attachedMagnet.magnetism=='n')magnetSprite.color = Color.red;
        }
        else
        {
            float newScaleY = buttonTop.localScale.y + Time.deltaTime;
            newScaleY = newScaleY <= topScale.y ? newScaleY : topScale.y;
            buttonTop.localScale = new Vector2(topScale.x, newScaleY);
            buttonTop.transform.localPosition = new Vector2(0, 0.25f + newScaleY / 2.0f);
            attachedMagnet.magnetPower = 0;
            magnetSprite.color = Color.white;
        }
    }
}
