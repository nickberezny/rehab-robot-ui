using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotInput : MonoBehaviour
{

    // Update is called once per frame
    [SerializeField] PlayerMotor playerMotor;
    RobotDataManager robotDataManager;

    private void Awake()
    {
        robotDataManager = RobotDataManager.Instance;
    }

    void Update()
    {
        playerMotor.changePos(Mathf.Clamp(robotDataManager.x, 0.0f, 1.0f));
    }
}
