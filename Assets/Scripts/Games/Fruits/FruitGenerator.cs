using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] fruits;
    [SerializeField] float difficultyRate;
    [SerializeField] Score score;


    public void createFruit(float pos)
    {
        //get x pos
        //set vel
        GameObject fruit = fruits[Mathf.RoundToInt(Random.Range(0, fruits.Length))];
        GameObject instance = Instantiate(fruit);
        instance.GetComponent<FruitMotor>().vel = 2;
        instance.GetComponent<FruitMotor>().score = score;
        instance.transform.position += new Vector3(pos, 6, 0);
    }


}
