using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class MainLevelUI : MonoBehaviour
{
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

    [SerializeField] GameObject _objective1;
    [SerializeField] GameObject _objective2;
    [SerializeField] GameObject _objective3;

    int _firstBugNumber = 5;
    int _secondBugNumber = 3;
    int _thirdBugNumber = 4;
    int _fourthBugNumber = 6;

    Vector2 _spawnLocation;
    [SerializeField] GameObject _prefabObject;
    //[SerializeField] Transform _spawnPoit1;
    //[SerializeField] Transform _spawnPoit2;
    //[SerializeField] Transform _spawnPoit3;
    // Start is called before the first frame update
    void Start()
    {
        _button1.interactable = false;
        _button2.interactable = false;
        _button3.interactable = false;
        _button4.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        TextUpdate();
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
        _button1.interactable = true;
        _button2.interactable = true;
        _button3.interactable = true;
        _button4.interactable = true;

        RectTransform uiElementRect = _attackButton1.GetComponent<RectTransform>();
        _spawnLocation = uiElementRect.position;
    }
    public void SecondAttackButtonPress()
    {
        _button1.interactable = true;
        _button2.interactable = true;
        _button3.interactable = true;
        _button4.interactable = true;

        RectTransform uiElementRect = _attackButton2.GetComponent<RectTransform>();
        _spawnLocation = uiElementRect.position;
    }
    public void ThirdAttackButtonPress()
    {
        _button1.interactable = true;
        _button2.interactable = true;
        _button3.interactable = true;
        _button4.interactable = true;

        RectTransform uiElementRect = _attackButton3.GetComponent<RectTransform>();
        //Vector3 uiElementScreenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, uiElementRect.position);
        //_spawnLocation = Camera.main.ScreenToWorldPoint(uiElementScreenPos);
        _spawnLocation = uiElementRect.position;
    }

    public void FirstBugSpawn()
    {
        if (_firstBugNumber < 1)
        {
            return;
        }
        _firstBugNumber--;
        Instantiate(_prefabObject, _spawnLocation, Quaternion.identity);
    }
    public void SecondBugSpawn()
    {
        if (_secondBugNumber < 1)
        {
            return;
        }
        _secondBugNumber--;
        Instantiate(_prefabObject, _spawnLocation, Quaternion.identity);
    }
    public void ThirdBugSpawn()
    {
        if (_thirdBugNumber < 1)
        {
            return;
        }
        _thirdBugNumber--;
        Instantiate(_prefabObject, _spawnLocation, Quaternion.identity);
    }
    public void FourthBugSpawn()
    {
        if (_fourthBugNumber < 1)
        {
            return;
        }
        _fourthBugNumber--;
        Instantiate(_prefabObject, _spawnLocation, Quaternion.identity);
    }
}
