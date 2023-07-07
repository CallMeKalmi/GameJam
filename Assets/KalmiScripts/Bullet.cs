using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float _speed = 20f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
}
