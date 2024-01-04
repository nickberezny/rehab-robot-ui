using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitMotor : MonoBehaviour
{
    [SerializeField] public float speed;
    float dt;

    private void Update()
    {
        dt = Time.deltaTime;

        transform.position += new Vector3(0, speed * dt, 0);

    }
}
