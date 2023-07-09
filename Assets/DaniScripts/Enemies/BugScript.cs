using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class BugScript : MonoBehaviour
{
    public int Health = 5;
    public float Speed = 1f;
    public Transform [] Waypoints;
    public Boolean TimerStart;
    public float Timer;
    public float SpeedTime;
    public GameObject button1, button2, button3;
    public Vector3 Button1Position, Button2Position, Button3Position;
    

    public Boolean TimerStart2;
    public Boolean StartMoving = true;
    public Boolean StartMoving1;
    public Boolean StartMoving2;
    public Boolean StartMoving3;
    public Boolean StartMoving4;
    public Boolean StartMoving5;
    public float Timer2;
    public float SpeedTime2;

    public bool Path1;
    public bool Path2;
    public bool Path3;
    // Start is called before the first frame update
    void Start()
    {
        //button1 = GameObject.FindGameObjectWithTag("Button1");
        //button2 = GameObject.FindGameObjectWithTag("Button2");
        //button3 = GameObject.FindGameObjectWithTag("Button3");

        //Button1Position = new Vector3(button1.transform.position.x, button1.transform.position.y, 0);
        //Button2Position = new Vector3(button2.transform.position.x, button2.transform.position.y, 0);
        //Button3Position = new Vector3(button3.transform.position.x, button3.transform.position.y, 0);
        Waypoints= new Transform[5];

        if (Path1)
        {
            Waypoints[0] = GameObject.FindGameObjectWithTag("W1").transform;
            Waypoints[1] = GameObject.FindGameObjectWithTag("W2").transform;
            Waypoints[2] = GameObject.FindGameObjectWithTag("W3").transform;
            Waypoints[3] = GameObject.FindGameObjectWithTag("W4").transform;
            Waypoints[4] = GameObject.FindGameObjectWithTag("W5").transform;
        }
        if (Path2)
        {
            Waypoints[0] = GameObject.FindGameObjectWithTag("L1").transform;
            Waypoints[1] = GameObject.FindGameObjectWithTag("L2").transform;
            Waypoints[2] = GameObject.FindGameObjectWithTag("L3").transform;
            Waypoints[3] = GameObject.FindGameObjectWithTag("L4").transform;
            Waypoints[4] = GameObject.FindGameObjectWithTag("L5").transform;
        }
        if (Path3)
        {
            Waypoints[0] = GameObject.FindGameObjectWithTag("R1").transform;
            Waypoints[1] = GameObject.FindGameObjectWithTag("R2").transform;
            Waypoints[2] = GameObject.FindGameObjectWithTag("R3").transform;
            Waypoints[3] = GameObject.FindGameObjectWithTag("R4").transform;
            Waypoints[4] = GameObject.FindGameObjectWithTag("R5").transform;
        }


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
            if (Timer2 > 2f)
            {
                Speed = 1f;
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
                Speed = 1f;
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
        Speed = 1.5f;
    }



    private void Move()
    {
        if (StartMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[0].position, Speed * Time.deltaTime);
        }

        if (StartMoving2)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[1].position, Speed * Time.deltaTime);
        }
        if (StartMoving3)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[2].position, Speed * Time.deltaTime);
        }
        if (StartMoving4)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[3].position, Speed * Time.deltaTime);
        }
        if (StartMoving5)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[4].position, Speed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, Waypoints[0].position) < 0.05f)
        {
            StartMoving = false;
            StartMoving2 = true;
        }
        if (Vector3.Distance(transform.position, Waypoints[1].position) < 0.05f)
        {
            StartMoving2 = false;
            StartMoving3 = true;
        }
        if (Vector3.Distance(transform.position, Waypoints[2].position) < 0.05f)
        {
            StartMoving3 = false;
            StartMoving4 = true;
        }
        if (Vector3.Distance(transform.position, Waypoints[3].position) < 0.05f)
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

    //void TakeNormalDamage(int damageAmount)
    //{
    //    Health = Health - damageAmount;
    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Bug")
    //    {
    //        Health--;
    //        Destroy(other.gameObject);
    //    }

    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Bullet"))
    //    {
    //        Debug.Log("Hit");
    //        Health--;
    //        Destroy(collision.gameObject);
    //    }
    //}
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
            Speed = 0.5f;
            TimerStart2 = true;
        }
    }
}
