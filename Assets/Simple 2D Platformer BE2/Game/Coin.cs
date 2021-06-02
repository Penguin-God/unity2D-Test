using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int score;

    private void Awake()
    {
        GameManager.instance.coinList.Add(gameObject);
        GameManager.instance.UpdateCoinCountText();
    }

    private void OnMouseDown()
    {
        GameManager.instance.gameScore += score;
        GameManager.instance.UpdateScoreText();
        GameManager.instance.coinList.Remove(gameObject);
        GameManager.instance.UpdateCoinCountText();
        Destroy(gameObject);
    }
}
