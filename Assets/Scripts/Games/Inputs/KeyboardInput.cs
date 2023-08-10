using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] PlayerMotor playerMotor;
    float dt;


    // Update is called once per frame
    void Update()
    {
        dt = Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerMotor.changePos(Mathf.Clamp(playerMotor.xn + speed * dt, 0.0f, 1.0f));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerMotor.changePos(Mathf.Clamp(playerMotor.xn - speed * dt, 0.0f, 1.0f));
        }
    }
}
