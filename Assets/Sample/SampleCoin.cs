using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCoin : MonoBehaviour
{
    public int score;

    private void Start()
    {
        SampleGameManager.instance.currentCoinList.Add(gameObject); // 리스트에 자신 추가
        SampleGameManager.instance.UpdateCoinCountText(); // 리스트 카운트 갱신
    }

    private void OnMouseDown()
    {


        // 점수 증가
        SampleGameManager.instance.gameScore += score; // 점수 변수 증가
        SampleGameManager.instance.UpdateScoreText(); // 점수 갱신

        SampleGameManager.instance.currentCoinList.Remove(gameObject); // 리스트에서 자신 삭제
        SampleGameManager.instance.UpdateCoinCountText(); // 리스트 카운트 갱신

        // 파괴
        Destroy(this.gameObject); 
    }
}
