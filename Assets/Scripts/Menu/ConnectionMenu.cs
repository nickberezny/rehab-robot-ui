using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionMenu : MonoBehaviour
{
    [SerializeField] Button _robot;
    [SerializeField] Button _openCV;

    [SerializeField] Image _robotLED;
    [SerializeField] Image _openCVLED;

    [SerializeField] Color _offColor;

    private void Awake()
    {
        _robot.interactable = false;
        _openCV.interactable = false;

        _robotLED.color = _offColor;
        _openCVLED.color = _offColor;
    }
    private void Start()
    {
        FindObjectOfType<Manager>().connectionMenu = this;
    }
    public void changeButtonInteractable(string buttonName, bool set)
    {
        if (buttonName == "ROBOT")
        {
            _robot.interactable = set;
            _robotLED.color = Color.white;
        }
        else if (buttonName == "OPENCV")
        {
            _openCV.interactable = set;
            _openCVLED.color = Color.white;
        }

    }
}
