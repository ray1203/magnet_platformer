using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpikes : MonoBehaviour
{
    [SerializeField]
    GameObject spike;
    [SerializeField]
    int count = 1;
    public void Start()
    {
        for(int i = 1; i < count; i++)
        {
            GameObject newObj = GameObject.Instantiate(spike,transform);
            newObj.transform.localPosition = new Vector2(i, 0);
        }
    }
}
