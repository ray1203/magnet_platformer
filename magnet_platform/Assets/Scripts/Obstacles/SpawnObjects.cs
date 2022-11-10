using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField]
    List<GameObject> objList = new List<GameObject>();
    [SerializeField]
    int count = 1;
    public void Awake()
    {
        if (objList.Count == 0) return;
        for(int i = objList.Count; i < count; i++)
        {
            GameObject newObj = GameObject.Instantiate(objList[i%objList.Count], transform);
            newObj.transform.localPosition = new Vector2(i, 0);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 center = new Vector3(transform.position.x + (float)(count-1) / 2.0f, transform.position.y, 0);
        Gizmos.DrawWireCube(center,new Vector3(count,1,0));  
    }
}
