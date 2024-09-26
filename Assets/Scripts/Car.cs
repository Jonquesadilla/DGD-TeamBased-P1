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
public class Car : MonoBehaviour
{
    public GameManager F;
    public string keyMoveForward;
    public string keyBrake;
    public string keyMoveReverse;
    public string keyRotateRight;
    public string keyRotateLeft;

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
    public enum state
    {
    }

    public state Current;
    
    public float score;
    public float Health;
    public Rigidbody2D RB;
    public BoxCollider2D CarCrash;
    public GameObject DeadGuy;

    public AudioSource Engine;
    public AudioClip vroom;

    public AudioSource hit;
    public AudioSource bonk;
    //timers

    void Start()
    {
        score = 0;
        Health = 4;
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
       /* 
        moveReverse = (Input.GetKeyDown(keyMoveReverse)) ? true : moveReverse;
        moveReverse = (Input.GetKeyUp(keyMoveReverse)) ? false : moveReverse;
        if (moveReverse)
        {
            moveSpeedReverse = (moveSpeedReverse < moveSpeedMax) ? moveSpeedReverse + moveAcceleration : moveSpeedMax; } else { moveSpeedReverse = (moveSpeedReverse > 0) ? moveSpeedReverse - moveDeceleration : 0;
        }
        transform.Translate(0f, moveSpeedReverse * Time.deltaTime * -1f, 0f);
*/
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
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("hit");
        }
    }
}
