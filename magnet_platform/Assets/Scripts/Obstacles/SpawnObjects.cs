using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField]
    List<GameObject> objList = new List<GameObject>();
    [SerializeField]
    int count = 1;
    private bool combineCol = true;
    public void Awake()
    {
        if (objList.Count == 0) return;
        for(int i = 0; i < objList.Count; i++)
        {
            if (!objList[i].CompareTag("Block")) { combineCol = false; break; }
            Rigidbody2D rb = objList[i].GetComponent<Rigidbody2D>();
            if (rb.constraints != RigidbodyConstraints2D.FreezeAll && rb.bodyType != RigidbodyType2D.Static) { combineCol = false; break; }

        }
        if (combineCol)
        {
            for (int i = 0; i < objList.Count; i++)
                objList[i].GetComponent<BoxCollider2D>().size = new Vector2(0.95f, 0.95f);
            BoxCollider2D box = gameObject.AddComponent<BoxCollider2D>();
            box.size = new Vector2(count, 1);
            box.offset = new Vector2((float)(count-1)/2.0f, 0);
        }
        for (int i = objList.Count; i < count; i++)
        {
            GameObject newObj = GameObject.Instantiate(objList[i%objList.Count], transform);
            newObj.transform.localPosition = new Vector2(i, 0);
        }
    }
    Vector3 Rotate(Vector3 pos,float rad)
    {
        float sin = Mathf.Sin(rad);
        float cos = Mathf.Cos(rad);
        return new Vector3(pos.x * cos - pos.y * sin, pos.y * cos + pos.x * sin, 1);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 center = 
            new Vector3((float)(count-1) / 2.0f,0, 0);
        float rad = transform.eulerAngles.z/180.0f*Mathf.PI;
        Vector3 v1 = new Vector3((float)count / 2.0f, 0.5f, 0);
        Vector3 v2 = new Vector3(-(float)count / 2.0f, 0.5f, 0);
        Vector3 v3 = new Vector3((float)count / 2.0f, -0.5f, 0);
        Vector3 v4 = new Vector3(-(float)count / 2.0f, -0.5f, 0);
        v1 = Rotate(v1, rad) + transform.position + Rotate(center,rad);
        v2 =  Rotate(v2, rad) +transform.position + Rotate(center, rad);
        v3 =  Rotate(v3, rad) +transform.position + Rotate(center, rad);
        v4 =  Rotate(v4, rad) +transform.position + Rotate(center, rad);

        Gizmos.DrawLine(v1,v2);
        Gizmos.DrawLine(v3,v4);
        Gizmos.DrawLine(v1,v3);
        Gizmos.DrawLine(v2,v4);
    }
}
