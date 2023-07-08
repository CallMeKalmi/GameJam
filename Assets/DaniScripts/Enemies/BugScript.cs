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
    public float Speed = 0.75f;
    public GameObject Goal;
    public Boolean TimerStart;
    public float Timer;
    public float SpeedTime;

    public Boolean TimerStart2;
    public float Timer2;
    public float SpeedTime2;
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
        StartTimer2();
    }

    private void StartTimer2()
    {
        if (TimerStart2 == true)
        {
            Timer2 = Timer2 + Time.deltaTime;
            if (Timer2 > 5f)
            {
                Speed = 0.75f;
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
