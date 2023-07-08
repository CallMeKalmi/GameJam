using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BugType4 : MonoBehaviour
{
    public int Health = 1;
    public float Speed = 1.5f;
    public Boolean TimerStart;
    public float Timer;
    public float SpeedTime;
    public GameObject[] Turrets;
    public int NumberTurrets;
    public float Distance;

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
    // Start is called before the first frame update
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
        CountTurrets();
        StartTimer2();
    }

    private void CountTurrets()
    {
        Turrets = GameObject.FindGameObjectsWithTag("Turret");
        NumberTurrets = Turrets.Length;
    }

    private void StartTimer2()
    {
        if (TimerStart2 == true)
        {
            Timer2 = Timer2 + Time.deltaTime;
            if (Timer2 > 2f)
            {
                Speed = 1.5f;
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
            if (Timer > 5f)
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
        Speed = 2f;
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
            DeactiveTurrets();
        }
    }

    private void DeactiveTurrets()
    {
        foreach (GameObject turret in Turrets)
        {
            if (turret != null)
            {
                Distance = Vector3.Distance(gameObject.transform.position, turret.transform.position);


                if (Distance < 2.5f)
                {
                    turret.gameObject.SendMessage("Deactivate");
                    Debug.Log(Distance);
                }
            }


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
            Health--;
        }
        if (collision.CompareTag("SlowBullet"))
        {
            Destroy(collision.gameObject);
            Health--;
            Speed = 1f;
            TimerStart2 = true;
        }
    }
}
