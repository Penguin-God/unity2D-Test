using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed;
    public 게임매니저 manager;
    float h;
    float v;
    bool xMove;
    //현재 바라보고있는 방향 값을 가진 변수 백터
    Vector3 dirvec;

    GameObject scan;
    Rigidbody2D rigid;
    Animator ani;
    private void Awake()
    {
        scan = GetComponent<GameObject>();
        rigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        h = manager.isaction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isaction ? 0 : Input.GetAxisRaw("Vertical");

        bool hDown = manager.isaction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isaction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isaction ? true : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isaction ? true : Input.GetButtonUp("Vertical");

        //대각선 이동 차단
        if (hDown)
            xMove = true;
        else if (vDown)
            xMove = false;
        else if (hUp || vUp)
            xMove = h != 0;

        //애니메이션
        if (ani.GetInteger("가로이동") != h)
        {
            ani.SetBool("방향전환", true);
            ani.SetInteger("가로이동", (int)h);
        }
        else if (ani.GetInteger("세로이동") != v)
        {
            ani.SetBool("방향전환", true);
            ani.SetInteger("세로이동", (int)v);
        }
        else
            ani.SetBool("방향전환", false);

        //direction(방향)
        if (vDown && v == 1)
            dirvec = Vector3.up;
        if (vDown && v == -1)
            dirvec = Vector3.down;
        if (hDown && h == 1)
            dirvec = Vector3.right;
        if (hDown && h == -1)
            dirvec = Vector3.left;

        //object scan
        if (Input.GetButtonDown("Jump") && scan != null)
            manager.Action(scan);
    }

    private void FixedUpdate()
    {
        //Move
        Vector2 moveVec = xMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;

        //Ray
        Debug.DrawRay(rigid.position, dirvec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayhit = Physics2D.Raycast(rigid.position, dirvec, 0.7f, LayerMask.GetMask("object"));

        if (rayhit.collider != null)
        {
            scan = rayhit.collider.gameObject;
        }
        else
            scan = null;
    }
}
