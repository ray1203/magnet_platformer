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
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        player = GameObject.FindWithTag("Player").gameObject;
        playerMagnet = player.GetComponentInChildren<PlayerMagnet>();
        playerMagnetCtrl = player.GetComponent<MagnetCtrl>();
        playerRigid = player.GetComponent<Rigidbody2D>();
        playerManager = player.GetComponent<PlayerManager>();
        playerMove = player.GetComponent<Player_Move>();
        fadeCanvas = Instantiate(fadeCanvas);
    }
    private void Start()
    {
        fadeEffect = fadeCanvas.transform.GetComponentInChildren<FadeEffect>();
        if (StageManager.instance == null)
        {
            GameObject stageManager = Instantiate(new GameObject("StageManager"));
            stageManager.AddComponent<StageManager>();
        }
    }
    public void GameOver()
    {
        GameObject newObject = Instantiate(playerDieEffect);
        newObject.transform.position = player.transform.position;
        player.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
