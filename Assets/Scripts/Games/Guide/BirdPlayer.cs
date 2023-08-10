using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPlayer : MonoBehaviour
{
    [SerializeField] Transform startPos, endPos;
    private Vector3 xs, xf, dir;

    private void Start()
    {

        xs = transform.position + startPos.position;
        xf = transform.position + endPos.position;
        dir = (endPos.position - startPos.position);
 
    }
}
