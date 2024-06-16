using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private MeshRenderer render;
    private Vector2 offset;
    public float x = 1f;
    public float y = 1f;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * speed * new Vector2(x,y);
        render.material.mainTextureOffset = offset;
    }
}
