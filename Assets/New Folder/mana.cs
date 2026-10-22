using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class mana : MonoBehaviour
{
    public GameObject coin;

    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject endPanel;

    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text endScoreText;

    public float gameTime = 20f;

    int state = 0; // 0开始 1游戏 2结束
    int score = 0;
    int highScore = 0;
    float timer;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        ShowStart();
    }

    void Update()
    {
        if (state == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                StartGame();
        }

        else if (state == 1)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                EndGame();
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mouse = Camera.main.ScreenToWorldPoint(
                    Input.mousePosition);

                Collider2D hit = Physics2D.OverlapPoint(mouse);

                if (hit != null && hit.gameObject == coin)
                {
                    score++;
                    MoveCoin();
                }
            }

            scoreText.text = "Score: " + score;
            timerText.text = "Time: " + Mathf.CeilToInt(timer);
        }

        else if (state == 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                ShowStart();
        }
    }

    void ShowStart()
    {
        state = 0;
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        endPanel.SetActive(false);
        coin.SetActive(false);
    }

    void StartGame()
    {
        state = 1;
        score = 0;
        timer = gameTime;

        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        endPanel.SetActive(false);
        coin.SetActive(true);

        MoveCoin();
    }

    void MoveCoin()
    {
        float x = Random.Range(-7f, 7f);
        float y = Random.Range(-3.5f, 3.5f);

        coin.transform.position = new Vector3(x, y, 0);
    }

    void EndGame()
    {
        state = 2;

        coin.SetActive(false);
        gamePanel.SetActive(false);
        endPanel.SetActive(true);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        endScoreText.text =
            "Score: " + score +
            "\nHigh Score: " + highScore;
    }
}
