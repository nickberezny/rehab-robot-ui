using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] Transform xstart, xend;
    [SerializeField] bool animateSprite;

    private Vector3 xs,xf;
    public float xn = 0.5f;
    private float xprev = 0.5f;
    SpriteRenderer renderer;
    Animator anim;

    RobotDataManager robotDataManager;

    private void Awake()
    {
        xs = xstart.position;// + transform.position;
        xf = xend.position;// + transform.position;

        renderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        robotDataManager = RobotDataManager.Instance;
    }

    public void changePos(float xnew)
    {
        
        transform.position = xnew * (xf - xs) + xs;
        xn = xnew;
    }

    private void Update()
    {
        transform.position= xs + robotDataManager.x * (xf - xs);

        if(animateSprite)
        {
            if (xn > xprev)
            {
                renderer.flipX = false;
                anim.SetBool("isRunning", true);

            }
            else if (xn < xprev)
            {
                renderer.flipX = true;
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }

            xprev = xn;
        }
        
    }


}
