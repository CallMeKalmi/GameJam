using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Objective : MonoBehaviour
{
    [SerializeField] int _hp = 2;
    [SerializeField] Button _button;
    // Update is called once per frame
    void Update()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
            _button.interactable = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bug"))
        {
            Destroy(collision.gameObject);
            _hp--;
        }
    }
}
