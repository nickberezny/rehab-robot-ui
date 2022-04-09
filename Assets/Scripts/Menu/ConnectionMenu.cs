using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionMenu : MonoBehaviour
{
    [SerializeField] Button _robot;
    [SerializeField] Button _openCV;

    private void Awake()
    {
        _robot.interactable = false;
        _openCV.interactable = false;
    }
    private void Start()
    {
        FindObjectOfType<Manager>().connectionMenu = this;
    }
    public void changeButtonInteractable(string buttonName, bool set)
    {
        if (buttonName == "ROBOT") _robot.interactable = set;
        else if (buttonName == "OPENCV") _openCV.interactable = set;

    }
}
