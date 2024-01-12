using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{

    float x_prev = 0.0f;
    SpriteRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.tag);
        if(collision.transform.tag == "Fruit")
        {
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        if(transform.position.x - x_prev > 0)
        {
            renderer.flipX = false;
        }
        else if(transform.position.x - x_prev < 0)
        {
            renderer.flipX = true;
        }

        x_prev = transform.position.x;
    }
}
