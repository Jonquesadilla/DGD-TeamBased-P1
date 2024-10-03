using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Car : MonoBehaviour
{
    public GameManager F;
    public TextMeshProUGUI Score;
    public string keyMoveForward;
    public string keyBrake;
    public string keyMoveReverse;
    public string keyRotateRight;
    public string keyRotateLeft;
    public GameObject Roadkill;

    bool moveForward = false;
    bool Brake = false;
    bool moveReverse = false;
    float moveSpeed = 0f;
    float moveSpeedReverse = 0f;
    float moveAcceleration = 0.1f;
    float moveDeceleration = 0.20f;
    float moveSpeedMax = 4.2f;

    bool rotateRight = false;
    bool rotateLeft = false;
    float rotateSpeedRight = 0f;
    float rotateSpeedLeft = 0f;
    float rotateAcceleration = 4f;
    float rotateDeceleration = 10f;
    float rotateSpeedMax = 200f;
    //Update is called once per frame

    public float score;
    public static float HighScore;
    public float Health;
    public Rigidbody2D RB;
    public BoxCollider2D CarCrash;
    public GameObject DeadGuy;

    

    public AudioSource Crash;
    public AudioClip crash;
    public AudioSource scream;
    public AudioClip Scream;
    public AudioSource Bonk;
    public AudioClip bonk;
    //timers

    void Start()
    {
        HighScore = 0;
        score = 0;
        Health = 5;
    }
     void Update()
    {
        
        rotateLeft = (Input.GetKeyDown(keyRotateLeft)) ? true : rotateLeft;
        rotateLeft = (Input.GetKeyUp(keyRotateLeft)) ? false : rotateLeft;
        if (rotateLeft)
        {
            rotateSpeedLeft = (rotateSpeedLeft < rotateSpeedMax) ? rotateSpeedLeft + rotateAcceleration : rotateSpeedMax; } else { rotateSpeedLeft = (rotateSpeedLeft > 0) ? rotateSpeedLeft - rotateDeceleration : 0;
        }
        transform.Rotate(0f, 0f, rotateSpeedLeft * Time.deltaTime);

        rotateRight = (Input.GetKeyDown(keyRotateRight)) ? true : rotateRight;
        rotateRight = (Input.GetKeyUp(keyRotateRight)) ? false : rotateRight;
        if (rotateRight)
        {
            rotateSpeedRight = (rotateSpeedRight < rotateSpeedMax) ? rotateSpeedRight + rotateAcceleration : rotateSpeedMax; } else { rotateSpeedRight = (rotateSpeedRight > 0) ? rotateSpeedRight - rotateDeceleration : 0;
        }
        transform.Rotate(0f, 0f, rotateSpeedRight * Time.deltaTime * -1f);

        moveForward = (Input.GetKeyDown(keyMoveForward)) ? true : moveForward;
        moveForward = (Input.GetKeyUp(keyMoveForward)) ? false : moveForward;
        if (moveForward)
        {
            moveSpeed = (moveSpeed < moveSpeedMax) ? moveSpeed + moveAcceleration : moveSpeedMax; } else { moveSpeed = (moveSpeed > 0) ? moveSpeed - moveDeceleration : 3;
        }
        transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);
        
        Brake = (Input.GetKeyDown(keyBrake)) ? true : Brake;
        Brake = (Input.GetKeyUp(keyBrake)) ? false : Brake;
        if (Brake)
        {
            moveForward = false;
        }
     
        moveReverse = (Input.GetKeyDown(keyMoveReverse)) ? true : moveReverse;
        moveReverse = (Input.GetKeyUp(keyMoveReverse)) ? false : moveReverse;
        if (moveReverse)
        {
            moveSpeedReverse = (moveSpeedReverse < moveSpeedMax) ? moveSpeedReverse + moveAcceleration : moveSpeedMax; } else { moveSpeedReverse = (moveSpeedReverse > 0) ? moveSpeedReverse - moveDeceleration : 0;
        }
        transform.Translate(0f, moveSpeedReverse * Time.deltaTime * -1f, 0f);
        Score.text = "Targets:" + score + "/13";
        if (score >= 13)
        {
            SceneManager.LoadScene("YouWin");
        }

        if (score > HighScore)
        {
            HighScore = score;
        }
    }
/*
    void Update()
    {
        //Declare variables -- unsanswerwed questions
        Vector2 Vel = RB.velocity;
        //Vector2 vel = RB.angularVelocity;
        //Find answers -- a bunch of if statement
        
        if (Input.GetKey(KeyCode.D))
        {
            Vel.x = 5;
          
          transform.localScale = new Vector3(1, 1, 1);
          
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vel.x = -5;
         
         //GetComponent<SpriteRenderer>()
         transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Vel.y = 5;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vel.y = -5;
        }
        // if (Input.GetKeyDown(KeyCode.Space))
       // {
       //     Instantiate(BulletPrefab, transform.position+new Vector3(2,0), quaternion.identity);
        //}
      

        //Plug in variables to stuff that maks things 
        RB.velocity = Vel;
       // RB.angularVelocity = vel;
    }
*/
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pedestrian")
        {
            Bonk.PlayOneShot(bonk);
            scream.PlayOneShot(Scream);
            Instantiate(Roadkill, transform.position+new Vector3(0,0), quaternion.identity);
            Debug.Log("hit");
            score += 1;
        }
        if (collision.gameObject.tag == "Buildings")
        {
            Crash.PlayOneShot(crash);
            Debug.Log("hit");
            Health -= 1;
        }
        if (collision.gameObject.tag == "Car")
        {
            Crash.PlayOneShot(crash);
            Debug.Log("hit");
            Health -= 1;
        }
    }
}
