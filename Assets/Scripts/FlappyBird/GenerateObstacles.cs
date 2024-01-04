using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacles : MonoBehaviour
{
    [SerializeField] GameObject pipes;
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    Manager manager;
    float x0;
    Vector3 start, end;
    GameObject pipeObject;

    private void Start()
    {
        manager = Manager.Instance;
        start = startPos.position;
        end = endPos.position;
    }

    private void Update()
    {
        if(manager.x0 != x0)
        {
            x0 = manager.x0;
            pipeObject = Instantiate(pipes, (start + x0 * (end - start)), Quaternion.identity);
            pipeObject.GetComponent<PipeMotor>().speed = -19.0f / manager.x0_duration;
        }
    }
}
