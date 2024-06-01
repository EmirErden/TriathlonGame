using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timeOutScreen : MonoBehaviour
{
    private bool isTimeOut = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTimeOut){
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
        isTimeOut = true;
        Time.timeScale = 0;
    }
}
