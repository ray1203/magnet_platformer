using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public static SpriteManager instance;
    public Sprite magnetN, magnetS,whiteTile,filledStar;
    private void Awake()
    {
        instance = this;
    }
}
