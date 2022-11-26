using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public Rigidbody2D playerRigid;
    public PlayerMagnet playerMagnet;
    public MagnetCtrl playerMagnetCtrl;
    public PlayerManager playerManager;
    public Player_Move playerMove;
    public GameObject playerDieEffect;
    public GameObject fadeCanvas;
    public FadeEffect fadeEffect;
    public List<KeyCtrl> keys = new List<KeyCtrl>();
    public int collectionCount = 0;
    public bool godMod = false;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        instance = this;
        player = GameObject.FindWithTag("Player").gameObject;
        playerMagnet = player.GetComponentInChildren<PlayerMagnet>();
        playerMagnetCtrl = player.GetComponent<MagnetCtrl>();
        playerRigid = player.GetComponent<Rigidbody2D>();
        playerManager = player.GetComponent<PlayerManager>();
        playerMove = player.GetComponent<Player_Move>();
        fadeCanvas = GameObject.Find("Canvas");
        if (StageManager.instance==null)
        {
            Debug.Log("StageManager create");
            GameObject stageManager = Instantiate(new GameObject("StageManager"));
            stageManager.AddComponent<StageManager>();
        }
    }
    private void Start()
    {
        fadeEffect = fadeCanvas.transform.GetComponentInChildren<FadeEffect>();
    }
    public void GameOver()
    {
        Time.timeScale = 1;
        if (godMod) return;
        GameObject newObject = Instantiate(playerDieEffect);
        newObject.transform.position = player.transform.position;
        player.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
