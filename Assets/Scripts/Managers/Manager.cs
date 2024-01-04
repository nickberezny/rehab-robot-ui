using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;
using System;

public class Manager : Singleton<Manager>
{
    public enum states { WaitForConn, WaitForRun, Running, Stop, Shutdown }
    public enum games { RobotGuide, CatchStuff, FlappyBird }
    public states state = states.WaitForConn;
    public games gameMode = games.RobotGuide;

    public float x = 0, x0 = 0;



    public IEnumerator RecieveMessage(string msg)
    {
        //
        Debug.Log(state);
        switch (state)
        {
            case states.WaitForConn:
                //set game, 
                //gameMode = (games)int.Parse(msg);
                LoadSceneByName(msg);
                Debug.Log(gameMode);
                state = states.WaitForRun;
                break;
            case states.WaitForRun:
                //load scene
                
                state = states.Running;
                break;
            case states.Running:
                
                string[] data = msg.Split(new string[] { "," }, StringSplitOptions.None);
                if(data[0] == "x")
                {
                    //state vars
                    x = float.Parse(data[1]);
                }
                else if(data[0] == "x0")
                {
                    //des pos
                    x0 = float.Parse(data[1]);
                }
                //robotDataManager.UpdatePosition(float.Parse(data[0]), float.Parse(data[1]));
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


}
