using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;

    Manager manager; 

    Vector3 start;
    Vector3 end;

    private void Start()
    {
        start = startPos.position;
        end = endPos.position;
        manager = Manager.Instance;
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = start + manager.x * (end - start);
    }
}
