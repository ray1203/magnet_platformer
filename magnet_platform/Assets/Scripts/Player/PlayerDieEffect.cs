using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieEffect : MonoBehaviour
{
    public void PlayerDieEffectEnd() {
        GameManager.instance.Restart();
    }
}
