using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortHonkTimer : MonoBehaviour
{
    
    public AudioSource AS;
    public AudioClip AC;

    public float timer = 5f;

    public float min = 10;

    public float max = 20;
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
