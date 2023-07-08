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


}
