using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] fruits;
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    Manager manager;
    float x0;
    Vector3 start, end;
    GameObject fruitObject;

    private void Start()
    {
        manager = Manager.Instance;
        start = startPos.position;
        end = endPos.position;
    }

    private void Update()
    {
        if (manager.x0 != x0)
        {
            x0 = manager.x0;
            int i = Random.Range(0, fruits.Length);
            fruitObject = Instantiate(fruits[i], (start + x0 * (end - start)), Quaternion.identity);
            fruitObject.GetComponent<FruitMotor>().speed = -9.5f / manager.x0_duration;
        }
    }
}
