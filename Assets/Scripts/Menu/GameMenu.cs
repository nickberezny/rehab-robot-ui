using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public void ButtonMessage(string msg)
    {
        Client2.Instance.SendTCPMessage("ROBOT::" + msg);
    }

}
