using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMenu : MonoBehaviour
{

    private void Start()
    {
        Manager.Instance.robotMenu = this;
    }

    public void ButtonMessage(string msg)
    {
        Client2.Instance.SendTCPMessage("ROBOT::" + msg);
    }
}
