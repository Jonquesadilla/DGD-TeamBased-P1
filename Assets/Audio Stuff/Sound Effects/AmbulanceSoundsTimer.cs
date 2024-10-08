using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceSoundsTimer : MonoBehaviour
{
    
    public AudioSource AS;
    public AudioClip AC;

    public float timer = 10f;

    public float min = 20;

    public float max = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            AS.PlayOneShot(AC);
            timer = Random.Range(min,max);
        }
    }
}
