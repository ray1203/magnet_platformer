using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public PlayerMagnet playerMagnet;
    public MagnetCtrl playerMagnetCtrl;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        player = GameObject.FindWithTag("Player").gameObject;
        playerMagnet = player.GetComponentInChildren<PlayerMagnet>();
        playerMagnetCtrl = player.GetComponent<MagnetCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
