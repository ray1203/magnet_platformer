using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float jumpPower;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {

        if (Input.GetButtonDown("Jump") && !anim.GetBool("IsJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true); //점프 애니메이션 미구현
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            anim.SetBool("IsWalking", false);
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //플레이어 바라보는 방향
        if (Input.GetButton("Horizontal"))
        {
            anim.SetBool("IsWalking", true);
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }


    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1))
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, 0.2f * Vector3.down, new Color(0, 1, 0));
            Debug.DrawRay(rigid.position + new Vector2(0.4f, 0), 0.2f * Vector3.down, new Color(0, 1, 0));
            Debug.DrawRay(rigid.position - new Vector2(0.4f, 0), 0.2f * Vector3.down, new Color(0, 1, 0));


            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 0.2f, LayerMask.GetMask("Platform"));
            RaycastHit2D rayHitL = Physics2D.Raycast(rigid.position - new Vector2(0.4f, 0), Vector3.down, 0.2f, LayerMask.GetMask("Platform"));
            RaycastHit2D rayHitR = Physics2D.Raycast(rigid.position + new Vector2(0.4f, 0), Vector3.down, 0.2f, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null || rayHitL.collider != null || rayHitR.collider != null)
            {
                anim.SetBool("IsJumping", false);
            }
            //레이캐스트로 바닥감지 점프는 1번만
        }
    }
}
