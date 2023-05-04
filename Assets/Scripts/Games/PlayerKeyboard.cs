using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboard : MonoBehaviour
{

    float vel = 0;
    float dt = 0;
    Animator anim;
    SpriteRenderer renderer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        dt = Time.deltaTime;

        vel = 0;

       if(Input.GetKey(KeyCode.RightArrow))
        {
            vel = 5;
            renderer.flipX = false;
        }
       else if(Input.GetKey(KeyCode.LeftArrow))
        {
            vel = -9;
            renderer.flipX = true;
        }

        transform.position += new Vector3(vel * dt, 0, 0);
        anim.SetBool("isRunning", !(bool)(vel == 0));
    }
}
