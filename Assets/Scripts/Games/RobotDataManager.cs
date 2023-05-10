using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDataManager: Singleton<RobotDataManager>
{
    public float x, x0;

    public void UpdatePosition(float xn, float x0n)
    {
        x = xn;
        x0n = x0;
    }
}
