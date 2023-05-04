using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitMotor : MonoBehaviour
{

    float dt = 0;
    public float vel = 1;
    public Score score;

    private void Update()
    {
        dt = Time.deltaTime;
        transform.position += new Vector3(0, -vel * dt, 0);

        if (transform.position.y < -10)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Position")
        {
        
            //play sound
            score.changeScore(1);
            Destroy(this.gameObject);
        }
    }
}
