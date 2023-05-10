using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPlayer : MonoBehaviour
{
    [SerializeField] Transform startPos, endPos;
    [SerializeField] Transform robotPos;
    [SerializeField] FruitGenerator generator;

    RobotDataManager robotDataManager;

    private Vector3 xs, xf;
    float x0 = 0;

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

    private void Update()
    {
        robotPos.position = xs + robotDataManager.x * (xf - xs);
        //generator.
        if(x0 != robotDataManager.x0)
        {
            x0 = robotDataManager.x0;
            generator.createFruit(x0);
        }
    }
}
