using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public Rigidbody2D playerRigid;
    public PlayerMagnet playerMagnet;
    public MagnetCtrl playerMagnetCtrl;
    public List<KeyCtrl> keys = new List<KeyCtrl>();
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        player = GameObject.FindWithTag("Player").gameObject;
        playerMagnet = player.GetComponentInChildren<PlayerMagnet>();
        playerMagnetCtrl = player.GetComponent<MagnetCtrl>();
        playerRigid = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
