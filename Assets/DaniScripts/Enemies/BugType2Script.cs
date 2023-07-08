using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class BugType2Script : MonoBehaviour
{
    public int Health = 3;
    public float Speed = 1.25f;
    //public MeshRenderer Renderer;
    //public Material[] Material;
    private int _index = 0;
    public GameObject Goal;
    public int NumberBugs;
    public float Distance;
    public GameObject[] Bugs;
    public Boolean TimerStart;
    public float Timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroyed();
        UpdateMaterial();
        Move();
        Arrived();
        ManualDamage();
        CountBugs();
        StartTimer();

    }

    private void StartTimer()
    {
        if (TimerStart == true)
        {
            Timer = Timer + Time.deltaTime;
            if (Timer > 5f)
            {
                Speed = 1.25f;
                Timer = 0;
                TimerStart = false;
            }
        }
    }

    private void CountBugs()
    {
        Bugs = GameObject.FindGameObjectsWithTag("Bug");
        NumberBugs = Bugs.Length;
    }



    private void Inspire()
    {
        foreach(GameObject go in Bugs )
        {
            if (go != null)
            {
                Distance = Vector3.Distance(gameObject.transform.position, go.transform.position);

                if (Distance < 2.5f)
                {
                    go.gameObject.SendMessage("Speedboost", 5f);
                }
            }


        }
    }

    void Speedboost(float timer)
    {
        TimerStart = true;
        Speed = 1.5f;
    }

    private void ManualDamage()
    {
        if (UnityEngine.Input.GetKeyDown("left shift"))
        {
            Health--;
        }
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

    private void UpdateMaterial()
    {
        //Renderer.material = Material[_index];
    }

    private void Destroyed()
    {
        if (Health < 1)
        {
            Destroy(gameObject);
            Inspire();
        }
    }

    //void TakeNormalDamage(int damageAmount)
    //{
    //    Health = Health - damageAmount;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Health--;
        }
    }


}
