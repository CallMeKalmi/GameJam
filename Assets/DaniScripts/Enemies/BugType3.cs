using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BugType3 : MonoBehaviour
{
    public int Health = 12;
    public float Speed = 0.4f;
    //public MeshRenderer Renderer;
    //public Material[] Material;
    public GameObject Goal;
    public Boolean TimerStart;
    public float Timer;
    public float SpeedTime;

    public Boolean TimerStart2;
    public float Timer2;
    public float SpeedTime2;
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroyed();
        Move();
        //Arrived();
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
        Speed = 1.25f;
    }

    private void Arrived()
    {
        if (transform.position == Goal.transform.position)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, Goal.transform.position, Speed * Time.deltaTime);
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
