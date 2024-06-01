using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    public bool isGameOver = false;
    public ScoreManager scoreManager;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI point;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = scoreManager.returnScore();
        scoreText.text = "Final Score: " + score.ToString();

        if(isGameOver){
            timer.gameObject.SetActive(false);
            point.gameObject.SetActive(false);
            if(Input.GetKeyDown(KeyCode.R)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1f;
        }   

        if(Input.GetKeyDown(KeyCode.Q)){
            UnityEditor.EditorApplication.isPlaying = false;
        }  
        }
    }

    public void Setup(){
        gameObject.SetActive(true);
        isGameOver = true;
        Time.timeScale = 0;
    }
}
