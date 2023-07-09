using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Objective : MonoBehaviour
{
    [SerializeField] int _hp = 2;
    [SerializeField] Button _button;
    //[SerializeField] int _numberOfObjectives;
    [SerializeField] string _nextSceneName;
    public AudioSource Src;
    public AudioClip Sfx1;
    // Update is called once per frame
    void Update()
    {
        if (_hp <= 0)
        {
            Src.clip = Sfx1;
            Src.volume = 0.05f;
            Src.Play();
            Destroy(gameObject);
            _button.interactable = false;
            MainLevelUI.NumberOfObjectives--;
            if (MainLevelUI.NumberOfObjectives < 1)
            {

                SceneManager.LoadScene(_nextSceneName);
            }
            
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
