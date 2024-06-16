using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
    public char magnetism = 'n';
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Color32 color;
            if (magnetism == 'n')
                color = new Color32(255, 87, 87, 255);
            else
                color = new Color32(87, 87, 255, 255);
            collision.gameObject.GetComponent<SpriteOutline>().color = color;
            collision.gameObject.transform.GetChild(1).GetComponent<SpriteOutline>().color = color;
            GameManager.instance.playerMagnetCtrl.magnetism = magnetism;
            Destroy(this.gameObject);
        }
    }
}
