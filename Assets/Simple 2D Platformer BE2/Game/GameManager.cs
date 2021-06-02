using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("GameManager 2개");
            Destroy(gameObject);
        }

        coinList = new List<GameObject>();
    }

    void Start()
    {
        StartCoroutine(CoinSpawn_Coroutine());
    }

    private void Update()
    {
        GameOver();

        if (isDead && Input.GetMouseButton(1))
        {
            ReStart();
        }
    }

    void ReStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public int gameScore;
    public Text scoreText;
    public void UpdateScoreText()
    {
        scoreText.text = "점수 : " + gameScore;
    }

    public Text coinCountText;
    public void UpdateCoinCountText()
    {
        coinCountText.text = "현재 코인 수 : " + coinList.Count;
    }

    public GameObject[] coins;
    public float spawnDelayTime;
    public GameObject spawnRangeObject;
    IEnumerator CoinSpawn_Coroutine()
    {
        while (true)
        {
            float randomDelayTime = Random.Range(0.2f, spawnDelayTime);
            yield return new WaitForSeconds(randomDelayTime);
            //Debug.Log(randomDelayTime);
            int randomCoinNumber = Random.Range(0, coins.Length);
            GameObject instantCoin = Instantiate(coins[randomCoinNumber], Return_CoinPosition(), transform.rotation);
        }
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

    public List<GameObject> coinList;
    public GameObject gameOverText;
    public Text gameOverScoreText;
    public bool isDead;
    void GameOver()
    {
        if (coinList.Count > 9)
        {
            CoinDontClick();
            isDead = true;
            Time.timeScale = 0;
            Set_GameOverUI();
        }
    }

    void Set_GameOverUI()
    {
        gameOverText.SetActive(true);
        gameOverScoreText.text = "최종 점수 : " + gameScore;
    }

    void CoinDontClick()
    {
        for(int i = 0; i < coinList.Count; i++)
        {
            coinList[i].GetComponent<Collider2D>().enabled = false;
        }
    }
}
