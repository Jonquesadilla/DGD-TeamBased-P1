using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI TimeTxt;
    public TextMeshProUGUI HP;
    public TextMeshProUGUI Score;
    public Car E;
    //public Enemy F;

    //public float Health;
    public float Timer = 0;

    public float score;

    public string Sscore;
    public float Health = 10;
    public GameObject Target;

    public List<GameObject> Guns = new List<GameObject>();
    // Start is called before the first frame update
    private void Start()
    {
        score = 0;
        Timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //score
       // Sscore = score.ToString();
       // Score.text = "Score:" + Sscore;
            //Health
        HP.text = "Health:" + E.Health;
        if (E.Health <= 0)
        {   
            E.Health = 0;
            SceneManager.LoadScene("Game Over");
        }
        //timer
        Timer += Time.deltaTime;
        TimeTxt.text = "Time:" + Mathf.Round(Timer);
        if (Timer <= 0)
        {
            Timer = 0;
        }
    }
    

}