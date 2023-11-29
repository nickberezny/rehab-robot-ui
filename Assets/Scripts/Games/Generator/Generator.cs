using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject[] objs;
    [SerializeField] Transform start, end;
    [SerializeField] float period;
    [SerializeField] Score score;
    private Vector3 xs, xf;

    private void Awake()
    {
        xs = start.position;
        xf = end.position;
    }

    private void Start()
    {
        StartCoroutine(generateObject());
    }

    IEnumerator generateObject()
    {
        while(true)
        {
            yield return new WaitForSeconds(period);
            GameObject instance = Instantiate(objs[Mathf.RoundToInt(Random.Range(0, objs.Length))]);
            instance.transform.position = Random.Range(0.0f,1.0f) * (xf - xs) + xs;
            instance.GetComponent<FruitMotor>().score = score;
        }
        
    }
}
