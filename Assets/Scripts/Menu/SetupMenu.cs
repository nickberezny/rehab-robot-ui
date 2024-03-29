using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupMenu : MonoBehaviour
{
    bool isReady = false;
    bool isWaitingForResponse = false;
    Dictionary<string, bool> finishedTasks = new Dictionary<string, bool>();
    Dictionary<string, float> p = new Dictionary<string, float>();
    Button[] buttons;


    private void Start()
    {
        Manager.Instance.setupMenu = this;

        finishedTasks.Add("HOME", false);
        finishedTasks.Add("CALIBRATE", false);

        buttons = GetComponentsInChildren<Button>();

        foreach (Button b in buttons)
        {
            b.onClick.AddListener(delegate { ButtonMessage(b.name.ToUpper()); });
            if (b.name == "Run" || b.name == "Stop") b.interactable = false;
        }




    }

    public void ButtonMessage(string msg)
    {
        if (msg != "NEXT") Client2.Instance.SendTCPMessage("ROBOT::" + msg);

        if (msg == "RUN")
        {
            Manager.Instance.state = Manager.states.Running;
            Manager.Instance.LoadSceneByName(Manager.Instance.gameMode.ToString());
            //load scene based on mode ->
            //Manager.Instance.LoadSceneByName("CatchStuff");
        }
   
    }


    public void StartingTask()
    {
        Debug.Log("Starting Task");
        isWaitingForResponse = true;
        SetInitButtons(false);
    }

    public void FinishTask(string task)
    {
        Debug.Log("Finished: " + ('H' == task[0]));
        finishedTasks[task] = true;
        isWaitingForResponse = false;
        SetInitButtons(true);
        CheckIfReady();
    }

    private void Update()
    {
        //FinishTask("Home");
        //FinishTask("Set");
        //FinishTask("Calibrate");
    }

    private void CheckIfReady()
    {
        if (finishedTasks.ContainsValue(false)) isReady = false;
        else
        {
            isReady = true;
            foreach (Button b in buttons)
            {
                if (b.name == "Run" || b.name == "Stop") b.interactable = true;
            }

        }
    }

    private void SetInitButtons(bool setVal)
    {
        foreach (Button b in buttons)
        {
            if (b.name == "Home"  || b.name == "Calibrate") b.interactable = setVal;
        }

    }

    

}
