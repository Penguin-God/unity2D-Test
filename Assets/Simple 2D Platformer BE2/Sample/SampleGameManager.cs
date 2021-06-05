using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SampleGameManager : MonoBehaviour
{
    public static SampleGameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("SampleGameManager 2개");
            Destroy(gameObject);
        }

        currentCoinList = new List<GameObject>();
    }




    // 코인 리스폰
    void Start()
    {
        
    }

    public List<GameObject> currentCoinList;
    public GameObject[] coins;
    public float spawnDelayTime;
    public GameObject spawnRangeObject;
    IEnumerator CoinSpawn_Coroutine()
    {
        yield return null;
    }

    Vector3 Return_CoinPosition()
    {
        float range_X = spawnRangeObject.GetComponent<BoxCollider2D>().bounds.size.x;
        float range_Y = spawnRangeObject.GetComponent<BoxCollider2D>().bounds.size.y;
        range_X = Random.Range(range_X / 2 * -1, range_X / 2);
        range_Y = Random.Range(range_Y / 2 * -1, range_Y / 2);
        Vector3 respawnPosition = new Vector3(range_X, range_Y, 0);
        return respawnPosition;
    }







    // 게임 오버 및 재시작
    private void Update()
    {
        GameOver();

        if (isDead && Input.GetMouseButton(1))
        {
            ReStart();
        }
    }

    public GameObject gameOverText;
    public Text gameOverScoreText;
    public bool isDead = false;
    void GameOver()
    {
        
    }

    void ReStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }







    // UI 업데이트
    public int gameScore;
    public Text scoreText;
    public void UpdateScoreText()
    {
        scoreText.text = "점수 : " + gameScore;
    }

    public Text coinCountText;
    public void UpdateCoinCountText()
    {
        coinCountText.text = "현재 코인 수 : " + currentCoinList.Count;
    }

    void Show_GameOverUI()
    {
        gameOverText.SetActive(true);
        gameOverScoreText.text = "최종 점수 : " + gameScore;
    }
}
