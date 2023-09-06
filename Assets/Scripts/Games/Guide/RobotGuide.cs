using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGuide : MonoBehaviour
{
    [SerializeField] Transform startPos, endPos;
    [SerializeField] Transform robotPos;
    [SerializeField] Transform desiredPos;

    RobotDataManager robotDataManager;

    private Vector3 xs, xf;

    Vector3 dir;

    private void Awake()
    {
        robotDataManager = RobotDataManager.Instance;
    }

    private void Start()
    {
       
        xs = transform.position + startPos.position;
        xf = transform.position + endPos.position;
        dir = (endPos.position - startPos.position);

    }

    private void FixedUpdate()
    {
        robotPos.position = xs + (robotDataManager.x)* (xf - xs);
        desiredPos.position = xs + robotDataManager.x0 * (xf - xs);
    }


}
