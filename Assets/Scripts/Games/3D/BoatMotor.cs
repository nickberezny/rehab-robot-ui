using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMotor : MonoBehaviour
{

    [SerializeField] float rot_speed;
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0,rot_speed,0));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0,-rot_speed,0));
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += speed*transform.TransformDirection(Vector3.fwd);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= speed*transform.TransformDirection(Vector3.fwd);
        }
    }
}
