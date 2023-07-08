using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RoseTower : MonoBehaviour
{
    
    [SerializeField] GameObject _bullet;
    //float speed = 5f;
    float _time = 0;
    float _fireRate = 2f;
    public Boolean TimerStart;
    public float Timer;
    public Boolean Active = true;

    private void Update()
    {
        if (Active == true)
        {
            
            //RotateTowards();
            Shoot();

        }
        UpdateTimer();



    }

    private void UpdateTimer()
    {
        if (TimerStart == true)
        {
            Timer = Timer + Time.deltaTime;
            if (Timer > 2)
            {
                Timer = 0;
                TimerStart = false;
                Active = true;

            }
        }

    }

    private void Shoot()
    {
        
        _time += Time.deltaTime;
        if (_time >= _fireRate)
        {
            _time = 0;
            Instantiate(_bullet, transform.position, transform.rotation);

        }


    }

    

    void Deactivate()
    {
        Active = false;
        TimerStart = true;
    }

    

    
}
