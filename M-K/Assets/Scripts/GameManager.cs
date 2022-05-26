using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    int score;
    int highscore;
    public static GameManager inst;

    public Text scoreText;
    [SerializeField] PlayerMovement playerMovement;
    public Text startingText;
    [SerializeField] TextMeshProUGUI highScoreText;

   public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;

        if(highscore < score)
            PlayerPrefs.SetInt("highscore", score);
        //PlayerPrefs.GetInt("HighScore");

        CheckHighScore();
        playerMovement.speed += playerMovement.speedIncreasedPerPoint;
    }

    void CheckHighScore()
    {
        if(score > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = $"highscore: {PlayerPrefs.GetInt("highscore",0)}";
    }

    public void IncrementBonus()
    {
        score += 5;
        scoreText.text = "SCORE: " + score;

        if(highscore < score)
            PlayerPrefs.SetInt("highscore", score);
        //PlayerPrefs.GetInt("HighScore");

        CheckHighScore();
    }

    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        UpdateHighScoreText();
        Time.timeScale = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            Destroy(startingText);
        }
    }
}
