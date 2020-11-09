﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    //public new Camera camera;
    float 회전속도 = 0;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
            }
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    회전속도 = Random.Range(-50f, 50.1f); //Random.Range(0, 10)은 0에서 9까지 반환함
        //    Debug.Log(회전속도);
        //}
        //rouletteClick();

        //회전 속도만큼 룰렛을 이동시킴
        //transform.Rotate(0, 0, 회전속도);
        //// Rotate : 오브젝트를 현재 각도에서 인수 값만큼 회전시키는 메서드, Rotate(x각도, y, z)로 사용, 값이 양수면 시계반대 방향 음수면 시계방향으로 회전

        //회전속도 *= 0.96f; //룰렛의 속도 감소
    }

    void rouletteClick()
    {
        Ray cameraRay = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        if (Physics.Raycast(cameraRay, out rayHit)) // out : ray에 닿은 물체를 리턴함
        {
            Debug.Log(rayHit.point);
            회전속도 = Random.Range(-50f, 50.1f); //Random.Range(0, 10)은 0에서 9까지 반환함
            for(int i = 0; i < 300; i++)
            {
                this.transform.Rotate(0, 0, 회전속도);
                회전속도 *= 0.96f; //룰렛의 속도 감소
            }
        }
    }
}
