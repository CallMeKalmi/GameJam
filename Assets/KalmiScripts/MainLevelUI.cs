using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class MainLevelUI : MonoBehaviour
{
    public static int NumberOfObjectives;
    [SerializeField] int _numberOfObjectives;

    [SerializeField] Button _button1;
    [SerializeField] Button _button2;
    [SerializeField] Button _button3;
    [SerializeField] Button _button4;

    [SerializeField] TextMeshProUGUI _button1Text;
    [SerializeField] TextMeshProUGUI _button2Text;
    [SerializeField] TextMeshProUGUI _button3Text;
    [SerializeField] TextMeshProUGUI _button4Text;

    [SerializeField] Button _attackButton1;
    [SerializeField] Button _attackButton2;
    [SerializeField] Button _attackButton3;

    //[SerializeField] GameObject _objective1;
    //[SerializeField] GameObject _objective2;
    //[SerializeField] GameObject _objective3;

    [SerializeField] int _firstBugNumber = 5;
    [SerializeField] int _secondBugNumber = 3;
    [SerializeField] int _thirdBugNumber = 4;
    [SerializeField] int _fourthBugNumber = 6;

    Vector3 _spawnLocation;
    [SerializeField] GameObject _prefabAnt1;
    [SerializeField] GameObject _prefabLadybug1;
    [SerializeField] GameObject _prefabBeetle1;
    [SerializeField] GameObject _prefabFly1;

    [SerializeField] GameObject _prefabAnt2;
    [SerializeField] GameObject _prefabLadybug2;
    [SerializeField] GameObject _prefabBeetle2;
    [SerializeField] GameObject _prefabFly2;

    [SerializeField] GameObject _prefabAnt3;
    [SerializeField] GameObject _prefabLadybug3;
    [SerializeField] GameObject _prefabBeetle3;
    [SerializeField] GameObject _prefabFly3;

    Transform _spawnPoit1;
    Transform _spawnPoit2;
    Transform _spawnPoit3;

    int _bugsLeft;

    GameObject _currentFirstBug;
    GameObject _currentSecondBug;
    GameObject _currentThirdBug;
    GameObject _currentFourthBug;

    float _time = 0;
    float _spawnRate = 0.25f;

    public AudioSource Src;
    public AudioClip Sfx1;

    // Start is called before the first frame update
    void Start()
    {
        DeactivateBottomButtons();
        
        NumberOfObjectives = _numberOfObjectives;

        _spawnPoit1 = _attackButton1.GetComponent<RectTransform>();
        _spawnPoit2 = _attackButton2.GetComponent<RectTransform>();
        _spawnPoit3 = _attackButton3.GetComponent<RectTransform>();
    }

    private void DeactivateBottomButtons()
    {
        _button1.interactable = false;
        _button2.interactable = false;
        _button3.interactable = false;
        _button4.interactable = false;
    }
    private void ActivateBottomButtons()
    {
        _button1.interactable = true;
        _button2.interactable = true;
        _button3.interactable = true;
        _button4.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        //AddBugsLeft();
        TextUpdate();
        CheckIfPathsAreAvalible();
    }

    //private void AddBugsLeft()
    //{
    //    _bugsLeft = _firstBugNumber + _secondBugNumber + _thirdBugNumber + _firstBugNumber;

    //    if (_bugsLeft<)
    //    {

    //    }
    //}

    private void CheckIfPathsAreAvalible()
    {
        if (!_attackButton1.IsInteractable())
        {
            if (_currentFirstBug == _prefabAnt1)
            {
                DeactivateBottomButtons();
            }
        }

        if (!_attackButton2.IsInteractable())
        {
            if (_currentFirstBug == _prefabAnt2)
            {
                DeactivateBottomButtons();
            }
        }
        if (!_attackButton3.IsInteractable())
        {
            if (_currentFirstBug == _prefabAnt3)
            {
                DeactivateBottomButtons();
            }
        }
    }

    private void TextUpdate()
    {
        _button1Text.text = _firstBugNumber.ToString();
        _button2Text.text = _secondBugNumber.ToString();
        _button3Text.text = _thirdBugNumber.ToString();
        _button4Text.text = _fourthBugNumber.ToString();
    }

    public void FirstAttackButtonPress()
    {
        _currentFirstBug = _prefabAnt1;
        _currentSecondBug= _prefabLadybug1;
        _currentThirdBug = _prefabBeetle1;
        _currentFourthBug = _prefabFly1;
        ActivateBottomButtons();
        //RectTransform uiElementRect = _attackButton1.GetComponent<RectTransform>();
        _spawnLocation = _spawnPoit1.position;
    }

    

    public void SecondAttackButtonPress()
    {
        _currentFirstBug = _prefabAnt2;
        _currentSecondBug = _prefabLadybug2;
        _currentThirdBug = _prefabBeetle2;
        _currentFourthBug = _prefabFly2;
        ActivateBottomButtons();

        //RectTransform uiElementRect = _attackButton2.GetComponent<RectTransform>();
        _spawnLocation = _spawnPoit2.position;
    }
    public void ThirdAttackButtonPress()
    {
        _currentFirstBug = _prefabAnt3;
        _currentSecondBug = _prefabLadybug3;
        _currentThirdBug = _prefabBeetle3;
        _currentFourthBug = _prefabFly3;
        ActivateBottomButtons();

        //RectTransform uiElementRect = _attackButton3.GetComponent<RectTransform>();
        //Vector3 uiElementScreenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, uiElementRect.position);
        //_spawnLocation = Camera.main.ScreenToWorldPoint(uiElementScreenPos);
        _spawnLocation = _spawnPoit3.position;
    }

    public void FirstBugSpawn()
    {
        if (_time < _spawnRate) return;
        _time = 0;
        if (_firstBugNumber < 1)
        {
            return;
        }
        _firstBugNumber--;
        _spawnLocation.z = 0;
        Instantiate(_currentFirstBug, _spawnLocation, Quaternion.identity);
        Src.clip = Sfx1;
        Src.volume = 0.2f;
        Src.Play();
    }
    

    public void SecondBugSpawn()
    {
        if (_time < _spawnRate) return;
        _time = 0;
        if (_secondBugNumber < 1)
        {
            return;
        }
        _secondBugNumber--;
        _spawnLocation.z = 0;
        Instantiate(_currentSecondBug, _spawnLocation, Quaternion.identity);
        Src.clip = Sfx1;
        Src.volume = 0.2f;
        Src.Play();
    }
    
    
    public void ThirdBugSpawn()
    {
        if (_time < _spawnRate) return;
        _time = 0;
        if (_thirdBugNumber < 1)
        {
            return;
        }
        _thirdBugNumber--;
        _spawnLocation.z = 0;
        Instantiate(_currentThirdBug, _spawnLocation, Quaternion.identity);
        Src.clip = Sfx1;
        Src.volume = 0.2f;
        Src.Play();
    }
    
    public void FourthBugSpawn()
    {
        if (_time < _spawnRate) return;
        _time = 0;
        if (_fourthBugNumber < 1)
        {
            return;
        }
        _fourthBugNumber--;
        _spawnLocation.z = 0;
        Instantiate(_currentFourthBug, _spawnLocation, Quaternion.identity);
        Src.clip = Sfx1;
        Src.volume = 0.2f;
        Src.Play();
    }
    

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
