using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class startScreen : MonoBehaviour
{

    public TextMeshProUGUI timer;
    public TextMeshProUGUI point;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Return)){
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            timer.gameObject.SetActive(true);
            point.gameObject.SetActive(true);
        }
    }
}
