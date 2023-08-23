using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotMenu : MonoBehaviour
{
    bool isReady = false;
    bool isWaitingForResponse = false;
    Dictionary<string, bool> finishedTasks = new Dictionary<string, bool>();
    Dictionary<string, float> p = new Dictionary<string, float>();
    Button[] buttons;

    [SerializeField] private RectTransform canvas;
    [SerializeField] private ParameterSelectView paramView;
    [SerializeField] private TrajectorySelectView trajView;
    [SerializeField] string nextSceneName;

    private void Start()
    {
        Manager.Instance.robotMenu = this;

        finishedTasks.Add("HOME", false);
        finishedTasks.Add("SET", false);
        finishedTasks.Add("CALIBRATE", false);

        buttons = GetComponentsInChildren<Button>();

        foreach (Button b in buttons)
        {
            b.onClick.AddListener(delegate { ButtonMessage(b.name.ToUpper()); });
            if (b.name == "Run" || b.name == "Stop" || b.name == "Next") b.interactable = false;

        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
        LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);


    }

    public void ButtonMessage(string msg)
    {
        if(msg != "NEXT") Client2.Instance.SendTCPMessage("ROBOT::" + msg);

        if (msg == "RUN")
        {
            Manager.Instance.state = Manager.states.Running;
            //load scene based on mode ->
            Manager.Instance.LoadSceneByName("CatchStuff");
        }
        else if (msg == "SET")
        {
            GetParams();
        }
        else if (msg == "NEXT")
        {
            Manager.Instance.LoadSceneByName(nextSceneName);
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


        foreach (Button b in buttons)
        {
            if (b.name == "Run" || b.name == "Stop" || b.name == "Next") b.interactable = true;
        }
                
        
    }

    private void SetInitButtons(bool setVal)
    {
        foreach (Button b in buttons)
        {
            if (b.name == "Home" || b.name == "Set" || b.name == "Calibrate") b.interactable = setVal;
        }

	LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
    }

    private void GetParams()
    {
        p.Clear();
        p = paramView.GetParams();

        Dictionary<string, float> p2 = new Dictionary<string, float>();

        string sendData = "ROBOT::";

        p2 = trajView.GetParams();

        foreach(string k in p2.Keys)
        {
            p.Add(k, p2[k]);
        }
        foreach (string s in p.Keys)
        {
            Debug.Log(s + p[s]);
            sendData = sendData.Insert(sendData.Length, s + p[s] + ",");
        }

        sendData = sendData.Insert(sendData.Length,"controlMode" + paramView.viewIndex.ToString()+",");
        sendData = sendData.Insert(sendData.Length,"trajMode" + trajView.viewIndex.ToString()+",");
        Debug.Log(sendData);
        Client2.Instance.SendTCPMessage(sendData);

	//Database.Instance.data = p;
    }

}
