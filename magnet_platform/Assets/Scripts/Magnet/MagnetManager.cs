using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MagnetManager : MonoBehaviour
{
    List<MagnetCtrl> magnetCtrls = new List<MagnetCtrl>();
    // Start is called before the first frame update
    void Start()
    {
        magnetCtrls =  new List<MagnetCtrl>(GameObject.FindObjectsOfType<MagnetCtrl>());
        Debug.Log(magnetCtrls.Count);
    }

    // Update is called once per frame
    void Update()
    {
        Calc();
    }

    void Calc()
    {
        Vector2[] powers = new Vector2[magnetCtrls.Count];
        for (int i = 0; i < magnetCtrls.Count; i++)
        {
            for (int j = i + 1; j < magnetCtrls.Count; j++)
            {
                Vector2 pos1 = magnetCtrls[i].transform.position;
                Vector2 pos2 = magnetCtrls[j].transform.position;
                float magnetPower = magnetCtrls[i].magnetPower * magnetCtrls[j].magnetPower;
                Vector2 dir = (-pos1 + pos2).normalized;
                float dist = (pos1 - pos2).sqrMagnitude;

                if (magnetCtrls[i].magnetism == magnetCtrls[j].magnetism)
                    dir = new Vector2(-dir.x, -dir.y);


                powers[i] += new Vector2(dir.x * magnetPower / dist, dir.y * magnetPower / dist);
                powers[j] += new Vector2(-dir.x * magnetPower / dist, -dir.y * magnetPower / dist);

            }
        }
        for(int i = 0; i < magnetCtrls.Count; i++)
        {
            magnetCtrls[i].power = powers[i];
        }
    }
}