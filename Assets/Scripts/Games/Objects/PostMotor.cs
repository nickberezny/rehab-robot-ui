using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostMotor : MonoBehaviour
{
    [SerializeField] float speed;
    private float dt;

    void Update()
    {
        dt = Time.deltaTime;
        transform.position += new Vector3(-speed * dt, 0, 0);
    }
}
