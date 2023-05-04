using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGuide : MonoBehaviour
{
    [SerializeField] Transform startPos, endPos;
    private Vector3 xs, xf;

    Vector3 dir;

    private void Start()
    {
        Manager.Instance.robotGuide = this.gameObject;
        xs = transform.position + startPos.position;
        xf = transform.position + endPos.position;
        dir = (endPos.position - startPos.position);

        transform.position = xs;
    }

    public void UpdatePosition(float normedPos)
    {
        transform.position = normedPos * dir + xs;
    }
}
