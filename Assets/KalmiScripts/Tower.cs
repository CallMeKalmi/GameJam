using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Tower : MonoBehaviour
{
    Transform _target;
    bool _thereIsTarget;
    [SerializeField] GameObject _bullet;
    //float speed = 5f;
    float _time = 0;
    float _fireRate = 1f;
    public Boolean TimerStart;
    public float Timer;
    public Boolean Active = true;

    private void Update()
    {
        if (Active == true)
        {
            if (_target == null)
            {
                _thereIsTarget = false;
            }
            RotateTowards();
            Shoot();

        }
        UpdateTimer();



    }

    private void UpdateTimer()
    {
        if(TimerStart == true)
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
        if (!_thereIsTarget)
        {
            _time = 0;
            return;
        }
        _time+= Time.deltaTime;
        if (_time >= _fireRate)
        {
            _time= 0;
            Instantiate(_bullet, transform.position, transform.rotation);
            
        }
        

    }

    private void RotateTowards()
    {
        if (_thereIsTarget)
        {
            Vector3 direction = _target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
    }

    void Deactivate()
    {
        Active =false;
        TimerStart = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_thereIsTarget)
        {
            return;
        }
        if (collision.CompareTag("Bug"))
        {
            _thereIsTarget= true;
            _target = collision.gameObject.transform;
            //Debug.Log("Bent van");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_thereIsTarget)
        {
            return;
        }
        if (collision.CompareTag("Bug"))
        {
            _thereIsTarget = true;
            _target = collision.gameObject.transform;
            //Debug.Log("Bent van");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bug"))
        {
            _thereIsTarget = false;
            
        }
    }
}
