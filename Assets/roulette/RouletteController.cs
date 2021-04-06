using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    //public new Camera camera;
    float 회전속도 = 0;
    public Camera Camera;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RouletteClick();
        }

        // 회전 속도만큼 룰렛을 이동시킴
        transform.Rotate(0, 0, 회전속도);
        // Rotate : 오브젝트를 현재 각도에서 인수 값만큼 회전시키는 메서드, Rotate(x각도, y, z)로 사용, 값이 양수면 시계반대 방향 음수면 시계방향으로 회전

        회전속도 *= 0.96f; //룰렛의 속도 감소
    }

    void RouletteClick()
    {
        Vector3 mousePos = Camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider != null)
        {
            회전속도 = Random.Range(-50f, 50f);
            Debug.Log(회전속도);
        }
    }
}


