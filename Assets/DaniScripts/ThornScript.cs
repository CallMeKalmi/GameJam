using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornScript : MonoBehaviour
{
    public float timer;
    float _speed = 5f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
        timer = timer + Time.deltaTime;
        if(timer > 0.75f)
        {
            Destroy(gameObject);
        }
    }

}
