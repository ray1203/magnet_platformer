using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMagnet : MonoBehaviour
{
    private float magnetDir = 0.0f;
    public List<MagnetCtrl> magnetCtrls = new List<MagnetCtrl>();
    public bool active = false;
    private List<Vector2> dirs = new List<Vector2>();

    private GameObject arm;
    private GameObject player;
    private SpriteOutline armOutline;
    private SpriteOutline playerOutline;
    private void Start()
    {
        dirs.Add(Vector2.left);
        dirs.Add(Vector2.right);
        dirs.Add(Vector2.up);
        dirs.Add(Vector2.down);
        player = GameManager.instance.player;
        arm = player.transform.Find("Arm").gameObject;

        armOutline = arm.GetComponent<SpriteOutline>();
        playerOutline = player.GetComponent<SpriteOutline>();
    }
    private void Update()
    {

        MouseInput();
        KeyInput();
        if (player.transform.localScale.x > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, magnetDir);
            arm.transform.rotation = Quaternion.Euler(0f, 0f, magnetDir);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, (magnetDir+180)%360);
            arm.transform.rotation = Quaternion.Euler(0f, 0f, (magnetDir+180)%360);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MagnetCtrl>(out var magnetCtrl))
        {
            magnetCtrls.Add(magnetCtrl);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MagnetCtrl>(out var magnetCtrl))
        {
            magnetCtrls.Remove(magnetCtrl);
        }
    }
    private void MouseInput()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Vector2 norm = ((Vector2)transform.position - mousePos).normalized;
            Vector2 center = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2));
            Vector2 norm = (center - mousePos).normalized;
            Vector2 dir = dirs[0];
            for (int i = 1; i < 4; i++)
                if (Vector2.Distance(norm, dirs[i]) > Vector2.Distance(norm, dir))
                    dir = dirs[i];

            if (dir == Vector2.left) magnetDir = 180f;
            else if (dir == Vector2.right) magnetDir = 0f;
            else if (dir == Vector2.up) magnetDir = 90f;
            else if (dir == Vector2.down) magnetDir = 270f;
        }
        if (Input.GetMouseButtonDown(0))
        {
            
            active = true;
            playerOutline.outlineSize = 1;
            armOutline.outlineSize = 1;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            active = false;
            playerOutline.outlineSize = 0;
            armOutline.outlineSize = 0;
        }
    }
    private void KeyInput()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            active = false;
            playerOutline.outlineSize = 0;
            armOutline.outlineSize = 0;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            active = true;
            playerOutline.outlineSize = 1;
            armOutline.outlineSize = 1;
            magnetDir = 180f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            active = true;
            playerOutline.outlineSize = 1;
            armOutline.outlineSize = 1;
            magnetDir = 0f;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            active = true;
            playerOutline.outlineSize = 1;
            armOutline.outlineSize = 1;
            magnetDir = 90f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            active = true;
            playerOutline.outlineSize = 1;
            armOutline.outlineSize = 1;
            magnetDir = 270f;
        }
    }
}