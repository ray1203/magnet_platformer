using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    private float magnetDir = 0.0f;
    public List<MagnetCtrl> magnetCtrls = new List<MagnetCtrl>();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))//180
        {
            magnetDir = 180f;
        }
        else if (Input.GetKeyDown(KeyCode.D))//0
        {
            magnetDir = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.W))//90
        {
            magnetDir = 90f;
        }
        else if (Input.GetKeyDown(KeyCode.S))//270
        {
            magnetDir = 270f;
        }
        transform.rotation = Quaternion.Euler(0f,0f,magnetDir);

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<MagnetCtrl>(out var magnetCtrl))
        {
            magnetCtrls.Add(magnetCtrl);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MagnetCtrl>(out var magnetCtrl))
        {
            magnetCtrls.Remove(magnetCtrl);
        }
    }
    public bool Find(MagnetCtrl magnetCtrl)
    {
        foreach(var i in magnetCtrls)
        {
            if (i == magnetCtrl) return true;
        }
        return false;
    }

}
