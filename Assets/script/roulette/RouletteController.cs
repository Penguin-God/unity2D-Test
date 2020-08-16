using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float 회전속도 = 0;

    private void Update()
    {
        //클릭하면 회전 속도를 설정한다.
        if (Input.GetMouseButtonDown(0))// 0이면 좌클릭, 1이면 우클릭, 2이면 마우스 휠을 클릭한 것입니다.
        {
            회전속도 = Random.Range(-50f, 50.1f); //Random.Range(0, 10)은 0에서 9까지 반환함
            Debug.Log(회전속도);
        }

        //회전 속도만큼 룰렛을 이동시킴
        transform.Rotate(0, 0, 회전속도);
        // Rotate : 오브젝트를 현재 각도에서 인수 값만큼 회전시키는 메서드, Rotate(x각도, y, z)로 사용, 값이 양수면 시계반대 방향 음수면 시계방향으로 회전

        회전속도 *= 0.96f; //룰렛의 속도 감소
    }
}
