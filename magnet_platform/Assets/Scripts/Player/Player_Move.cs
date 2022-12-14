using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;

    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float DashSpeed;
    [SerializeField]
    private float jumpPower;
    
    private List<Transform> bottomBlocks = new List<Transform>();
    private GameObject player;
    private PlayerMagnet playerMagnet;
    private PlayerManager playerManager;
    private float walKSoundCool = 0;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        player = GameManager.instance.player;
        playerMagnet = GameManager.instance.playerMagnet;
        playerManager = GameManager.instance.playerManager;
    }
    void Update()
    {

        if (Input.GetButtonDown("Jump") && !anim.GetBool("IsJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true); 
            for (int i = 0; i < bottomBlocks.Count; i++)
                if (bottomBlocks[i].TryGetComponent<Rigidbody2D>(out Rigidbody2D rdbd))
                    rdbd.AddForce(Vector2.down * jumpPower, ForceMode2D.Impulse);

            AddForceToBlock(Vector2.up * jumpPower);
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            anim.SetBool("IsWalking", false);
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }


        if (Input.GetButton("Horizontal"))
        {
            anim.SetBool("IsWalking", true);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Mathf.Sign(Input.GetAxisRaw("Horizontal")), transform.localScale.y, 1);
        }


    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        float DashMaxSpeed = maxSpeed;
        anim.speed = 1;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            DashMaxSpeed = DashSpeed * maxSpeed;
            anim.speed = DashSpeed;
        }
        if (rigid.velocity.x > DashMaxSpeed)
            rigid.velocity = new Vector2(DashMaxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < DashMaxSpeed * (-1))
            rigid.velocity = new Vector2(DashMaxSpeed * (-1), rigid.velocity.y);

        Debug.DrawRay(rigid.position, 0.2f * Vector3.down, new Color(0, 1, 0));
        Debug.DrawRay(rigid.position + new Vector2(0.4f, 0), 0.2f * Vector3.down, new Color(0, 1, 0));
        Debug.DrawRay(rigid.position - new Vector2(0.4f, 0), 0.2f * Vector3.down, new Color(0, 1, 0));


        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 0.2f, LayerMask.GetMask("Platform"));
        RaycastHit2D rayHitL = Physics2D.Raycast(rigid.position - new Vector2(0.4f, 0), Vector3.down, 0.2f, LayerMask.GetMask("Platform"));
        RaycastHit2D rayHitR = Physics2D.Raycast(rigid.position + new Vector2(0.4f, 0), Vector3.down, 0.2f, LayerMask.GetMask("Platform"));
        if (rayHit.collider != null || rayHitL.collider != null || rayHitR.collider != null)
        {
            if (Input.GetButton("Horizontal"))
                walkSound();
            bottomBlocks.Clear();
            if (rayHit.collider != null && !bottomBlocks.Contains(rayHit.transform)) bottomBlocks.Add(rayHit.transform);
            if (rayHitL.collider != null && !bottomBlocks.Contains(rayHitL.transform)) bottomBlocks.Add(rayHitL.transform);
            if (rayHitR.collider != null && !bottomBlocks.Contains(rayHitR.transform)) bottomBlocks.Add(rayHitR.transform);
            if (rigid.velocity.y < 0)
                anim.SetBool("IsJumping", false);
        }

    }
    void AddForceToBlock(Vector2 force)
    {
        if (playerMagnet.active)
            foreach (var i in playerManager.blocks)
                if (playerMagnet.magnetCtrls.Contains(i))
                    if (i.transform.TryGetComponent<Rigidbody2D>(out Rigidbody2D rgbd))
                        rgbd.AddForce(force * rgbd.mass / playerManager.rgbd.mass, ForceMode2D.Impulse);
    }
    public void MultiplyJumpPower(float amount)
    {
        jumpPower *= amount;
    }

    public void StopMovement()
    {
        maxSpeed = 0;
        DashSpeed = 0;
        jumpPower = 0;
    }

    public void walkSound()
    {
        walKSoundCool += Time.deltaTime * anim.speed;
        if (walKSoundCool >= 0.5f)
        {
            audioSource.Play();
            walKSoundCool = 0;
        }
    }
}
