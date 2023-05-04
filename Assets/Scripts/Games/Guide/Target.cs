using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] Color _red;
    [SerializeField] Color _green;

    private BoxCollider2D col;
    private SpriteRenderer sprite;

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision: " + collision.tag);
        if(collision.tag == "Position")
        {
            sprite.color = _green;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Position")
        {
            sprite.color = _red;
        }
    }
}
