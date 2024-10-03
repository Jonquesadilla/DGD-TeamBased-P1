using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DText : MonoBehaviour
{

    public TMP_Text StartText;
    
    public float Timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Timer = Timer - 1;
        
        
        if (Timer <= 0.0f)
        {
            
            StartText.color = Color.white;
            
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Joncarlos2");
            StartText.text = "Loading...";

        }
        
    }
}
