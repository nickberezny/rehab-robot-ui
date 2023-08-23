﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;
using System;

public class Manager : Singleton<Manager>
{
    public enum states { Init, WaitForConn, InitDevice, Running, Stop, Shutdown  }
    public enum games {RobotGuide, CatchStuff, FlappyBird}
    public states state = states.Init;
    public games gameMode = games.RobotGuide;

    public ConnectionMenu connectionMenu;
    public RobotMenu robotMenu;
    public SetupMenu setupMenu;
    public RobotDataManager robotDataManager;

    

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
			        LoadSceneByName("ActivityMenu");
		        }
                else
                {
                    string[] data = msg.Split(new string[] { "," }, StringSplitOptions.None);
                    robotDataManager.UpdatePosition(float.Parse(data[0]), float.Parse(data[1]));
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
            if (robotMenu) robotMenu.StartingTask();
            if (setupMenu) setupMenu.StartingTask();
        }
        else
        {
            if(robotMenu) robotMenu.FinishTask(msg);
            if (setupMenu) setupMenu.FinishTask(msg);
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
