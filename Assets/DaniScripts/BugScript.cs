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
    //public MeshRenderer Renderer;
    //public Material[] Material;
    private int _index = 0;
    public GameObject Goal;
    public Boolean TimerStart;
    public float Timer;
    public float SpeedTime;
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
        //Arrived();
        ManualDamage();
        StartTimer();
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

    private void UpdateMaterial()
    {
        //Renderer.material = Material[_index];
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
    }
}
