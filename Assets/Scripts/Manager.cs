using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public enum states { Init, WaitForConn, InitDevice, Running, Stop, Shutdown  }
    public states state = states.Init;

    public ConnectionMenu connectionMenu;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public IEnumerator RecieveMessage(string msg)
    {
        //
        switch(state)
        {
            case states.WaitForConn:
                WaitForConnMessageHandler(msg);
                break;
            default:
                break;
        }
        yield return null;
    }

    private void WaitForConnMessageHandler(string msg)
    {
        switch(msg)
        {
            case "ROBOT":
                Debug.Log("robot!");
                connectionMenu.changeButtonInteractable(msg, true);
                break;
            case "OPENCV":
                connectionMenu.changeButtonInteractable(msg, true);
                break;
            default:
                break;
        }
    }

    //connect to server
    //wait for available devices
    //enable select buttons 

}
