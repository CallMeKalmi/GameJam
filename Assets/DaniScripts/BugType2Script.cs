using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class BugType2Script : MonoBehaviour
{
    public int Health = 3;
    //public MeshRenderer Renderer;
    //public Material[] Material;
    private int _index = 0;
    public GameObject Goal;
    public int NumberBugs;
    public float Distance;
    public GameObject[] Bugs;
    public GameObject [] CloseBugs;
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
        CheckForCloseBugs();
        Inspire();
    }

    private void CountBugs()
    {
        Bugs = GameObject.FindGameObjectsWithTag("Bug");
        NumberBugs = Bugs.Length;
    }

    private void CheckForCloseBugs()
    {
        for(int i = 0; i < NumberBugs; i++) 
        {
            foreach(GameObject go in Bugs)
            {
                Distance = Vector3.Distance(gameObject.transform.position, Bugs[i].transform.position);

                if (Distance < 5)
                {
                    CloseBugs[i] =  go;
                }
            }

        }
    }

    private void Inspire()
    {

        //if (UnityEngine.Input.GetKeyDown(""))
        //{
        //    foreach(Collider c in CloseBugs)
        //    {
                
        //    }
        //}
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
        transform.position = Vector3.MoveTowards(transform.position, Goal.transform.position, 0.75f * Time.deltaTime);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Health--;
        }
    }


}
