using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotMenu : MonoBehaviour
{
    bool isReady = false;
    bool isWaitingForResponse = false;
    Dictionary<string, bool> finishedTasks = new Dictionary<string, bool>();
    Button[] buttons;

    [SerializeField] private RectTransform canvas;

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
            if (b.name == "Run" || b.name == "Stop") b.interactable = false;
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);

    }

    public void ButtonMessage(string msg)
    {
        Client2.Instance.SendTCPMessage("ROBOT::" + msg);
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
            if (b.name == "Home" || b.name == "Set" || b.name == "Calibrate") b.interactable = setVal;
        }
    }

}
