using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : Singleton<Manager>
{
    public enum states { Init, WaitForConn, InitDevice, Running, Stop, Shutdown  }
    public states state = states.Init;

    public ConnectionMenu connectionMenu;
    public RobotMenu robotMenu;
    public GameObject robotGuide;

    public IEnumerator RecieveMessage(string msg)
    {
        //
        Debug.Log(state);
        switch (state)
        {
            case states.WaitForConn:
                WaitForConnMessageHandler(msg);
                break;
            case states.InitDevice:
                InitDevicesMessageHandler(msg);
                break;
            case states.Running:
		if(msg == "STOP")
		{
			state = states.InitDevice;
			LoadSceneByName("RobotMenu");
		}
                else if(robotGuide)
                {
                    robotGuide.GetComponent<RobotGuide>().UpdatePosition(float.Parse(msg)/1000.0f);
                }
                break;
            default:
                break;
        }
        yield return null;
    }

    public void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }


    private void InitDevicesMessageHandler(string msg)
    {
        Debug.Log("Init Msg");
        if (msg == "STARTTASK")
        {
            robotMenu.StartingTask();
        }
        else
        {
            robotMenu.FinishTask(msg);
        }
    }

    private void WaitForConnMessageHandler(string msg)
    {
        switch(msg)
        {
            case "ROBOT":
                Debug.Log("robot!");
                connectionMenu.changeButtonInteractable(msg, true);
                state = states.InitDevice;
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
