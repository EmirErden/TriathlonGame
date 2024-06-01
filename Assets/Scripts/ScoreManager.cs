using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI HighscoreText;
    public gameOver gameOver;
    public timeOutScreen timeOutScreen;
    int point = 0;
    int score = 0;
    private double timer = 90;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("Highscore")){
            PlayerPrefs.SetInt("HighScore", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = "Point: " + point.ToString();
        timer -= Time.deltaTime;
        timeText.text = "Timer: " + timer.ToString("F1");

        if(gameOver.isGameOver){
            int intTimer = (int) timer;
            score = point + intTimer * 50;
            if(score > getHighScore()){
                HighscoreText.text = "NEW HIGHSCORE: " + score.ToString();
                HighscoreText.color = Color.blue;
                setHighScore(score);                   
            } if(score < getHighScore()) {
                HighscoreText.color = Color.white;
                HighscoreText.text = "Highscore: " + getHighScore().ToString();
            }
        }

        if(timer <= 0){
            timeOutScreen.Setup();
        }
    }

    public void setHighScore(int score){
        PlayerPrefs.SetInt("Highscore", score);
    }

    public int getHighScore(){
        int HighScore = PlayerPrefs.GetInt("Highscore");
        return HighScore;
    }

    public int returnPoint(){
        return point;
    }

    public void addPoint(){
        point += 100;
    }

    public int returnScore(){
        return score;
    }
}
