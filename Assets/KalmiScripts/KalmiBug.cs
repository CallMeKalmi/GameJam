using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalmiBug : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            //Health--;
        }
    }
}
