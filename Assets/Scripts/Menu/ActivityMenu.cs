using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityMenu : MonoBehaviour
{
    public void chooseGame(int game)
    {
        Manager.Instance.gameMode = (Manager.games)game;

    }

    public void nextScreen()
    {
        Manager.Instance.LoadSceneByName("RobotMenu");
    }
}
