using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class YouWin : MonoBehaviour

{
    //public static float HighScore;
    public TextMeshProUGUI Highscore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Highscore.text = "Best time:"+ GameManager.Timer;
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Main Scene");
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene("Title Screen");
        }
    }
}
