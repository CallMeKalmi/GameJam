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

    int _firstBugNumber = 5;
    int _secondBugNumber = 3;
    int _thirdBugNumber = 4;
    int _fourthBugNumber = 6;

    Vector3 _spawnLocation;
    [SerializeField] GameObject _prefabAnt;
    [SerializeField] GameObject _prefabLadybug;
    [SerializeField] GameObject _prefabBeetle;
    [SerializeField] GameObject _prefabFly;
    Transform _spawnPoit1;
    Transform _spawnPoit2;
    Transform _spawnPoit3;

    int _bugsLeft;
    
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
            if (_spawnLocation == _spawnPoit1.position)
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
        ActivateBottomButtons();
        //RectTransform uiElementRect = _attackButton1.GetComponent<RectTransform>();
        _spawnLocation = _spawnPoit1.position;
    }

    

    public void SecondAttackButtonPress()
    {
        ActivateBottomButtons();

        //RectTransform uiElementRect = _attackButton2.GetComponent<RectTransform>();
        _spawnLocation = _spawnPoit2.position;
    }
    public void ThirdAttackButtonPress()
    {
        ActivateBottomButtons();

        //RectTransform uiElementRect = _attackButton3.GetComponent<RectTransform>();
        //Vector3 uiElementScreenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, uiElementRect.position);
        //_spawnLocation = Camera.main.ScreenToWorldPoint(uiElementScreenPos);
        _spawnLocation = _spawnPoit3.position;
    }

    public void FirstBugSpawn()
    {
        if (_firstBugNumber < 1)
        {
            return;
        }
        _firstBugNumber--;
        _spawnLocation.z = 0;
        Instantiate(_prefabAnt, _spawnLocation, Quaternion.identity);
    }
    public void SecondBugSpawn()
    {
        if (_secondBugNumber < 1)
        {
            return;
        }
        _secondBugNumber--;
        _spawnLocation.z = 0;
        Instantiate(_prefabLadybug, _spawnLocation, Quaternion.identity);
    }
    public void ThirdBugSpawn()
    {
        if (_thirdBugNumber < 1)
        {
            return;
        }
        _thirdBugNumber--;
        _spawnLocation.z = 0;
        Instantiate(_prefabBeetle, _spawnLocation, Quaternion.identity);
    }
    public void FourthBugSpawn()
    {
        if (_fourthBugNumber < 1)
        {
            return;
        }
        _fourthBugNumber--;
        _spawnLocation.z = 0;
        Instantiate(_prefabFly, _spawnLocation, Quaternion.identity);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
