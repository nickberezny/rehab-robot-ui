using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMotor : MonoBehaviour
{
    [SerializeField] public float speed;
    float dt;

    private void Update()
    {
        dt = Time.deltaTime;

        transform.position += new Vector3(speed * dt, 0, 0);

    }
}
