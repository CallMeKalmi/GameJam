using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BugType3 : MonoBehaviour
{
    public int Health = 12;
    public float Speed = 0.4f;
    public Boolean TimerStart;
    public float Timer;
    public float SpeedTime;

    public Boolean TimerStart2;
    public float Timer2;
    public float SpeedTime2;

    public Boolean StartMoving = true;
    public Boolean StartMoving1;
    public Boolean StartMoving2;
    public Boolean StartMoving3;
    public Boolean StartMoving4;
    public Boolean StartMoving5;

    public Transform[] Waypoints;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroyed();
        Move();
        ManualDamage();
        StartTimer();
        StartTimer2();

    }

    private void StartTimer2()
    {
        if (TimerStart2 == true)
        {
            Timer2 = Timer2 + Time.deltaTime;
            if (Timer2 > 5f)
            {
                Speed = 0.4f;
                Timer2 = 0;
                TimerStart2 = false;
            }
        }
    }
    private void StartTimer()
    {
        if (TimerStart == true)
        {
            Timer = Timer + Time.deltaTime;
            if (Timer > 2f)
            {
                Speed = 0.75f;
                Timer = 0;
                TimerStart = false;
            }
        }
    }

    private void ManualDamage()
    {
        if (UnityEngine.Input.GetKeyDown("left shift"))
        {
            Health--;
        }
    }

    void Speedboost(float timer)
    {
        TimerStart = true;
        Speed = 0.6f;
    }

    private void Move()
    {
        if (StartMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[0].transform.position, Speed * Time.deltaTime);
        }

        if (StartMoving2)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[1].transform.position, Speed * Time.deltaTime);
        }
        if (StartMoving3)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[2].transform.position, Speed * Time.deltaTime);
        }
        if (StartMoving4)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[3].transform.position, Speed * Time.deltaTime);
        }
        if (StartMoving5)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[4].transform.position, Speed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, Waypoints[0].transform.position) < 0.05f)
        {
            StartMoving = false;
            StartMoving2 = true;
        }
        if (Vector3.Distance(transform.position, Waypoints[1].transform.position) < 0.05f)
        {
            StartMoving2 = false;
            StartMoving3 = true;
        }
        if (Vector3.Distance(transform.position, Waypoints[2].transform.position) < 0.05f)
        {
            StartMoving3 = false;
            StartMoving4 = true;
        }
        if (Vector3.Distance(transform.position, Waypoints[3].transform.position) < 0.05f)
        {
            StartMoving4 = false;
            StartMoving5 = true;
        }
    }



    private void Destroyed()
    {
        if (Health < 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Health--;
        }

        if (collision.CompareTag("Thorn"))
        {
            Destroy(collision.gameObject);
            Health = Health - 3;
        }
        if (collision.CompareTag("SlowBullet"))
        {
            Destroy(collision.gameObject);
            Health--;
            Speed = 0.2f;
            TimerStart2 = true;
        }
    }
}