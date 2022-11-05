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
    //플레이어 하단의 블럭을 끌어당기면서 점프하면 무한점프 되는 문제 해결용
    private List<Transform> bottomBlocks = new List<Transform>();
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
            for (int i = 0; i < bottomBlocks.Count; i++)
            {
                if(bottomBlocks[i].TryGetComponent<Rigidbody2D>(out Rigidbody2D rdbd))
                {
                    rdbd.AddForce(Vector2.down * jumpPower, ForceMode2D.Impulse);
                }
            }
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
            transform.localScale = new Vector3(2 * Input.GetAxisRaw("Horizontal"), 2, 1);
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
                bottomBlocks.Clear();
                if (rayHit.collider != null && !bottomBlocks.Contains(rayHit.transform)) bottomBlocks.Add(rayHit.transform);
                if (rayHitL.collider != null && !bottomBlocks.Contains(rayHitL.transform)) bottomBlocks.Add(rayHitL.transform);
                if (rayHitR.collider != null && !bottomBlocks.Contains(rayHitR.transform)) bottomBlocks.Add(rayHitR.transform);
                anim.SetBool("IsJumping", false);
            }
            //레이캐스트로 바닥감지 점프는 1번만
        }
    }
}
