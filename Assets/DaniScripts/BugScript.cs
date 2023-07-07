using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using static UnityEngine.GraphicsBuffer;

public class BugScript : MonoBehaviour
{
    public int Health = 5;
    //public MeshRenderer Renderer;
    //public Material[] Material;
    private int _index = 0;
    public GameObject Goal;
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
        transform.position = Vector3.MoveTowards(transform.position, Goal.transform.position, 0.001f);
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bug")
        {
            Health--;
            Destroy(other.gameObject);
        }

    }


}
