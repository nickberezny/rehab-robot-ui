using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] fruits;
    [SerializeField] float difficultyRate;
    [SerializeField] Score score;

    private void Start()
    {
        StartCoroutine(MakeFruit(difficultyRate));
    }

    private void createFruit()
    {
        //get x pos
        //set vel
        float pos = Random.Range(-5,5);

        GameObject fruit = fruits[Mathf.RoundToInt(Random.Range(0, fruits.Length))];
        GameObject instance = Instantiate(fruit);
        instance.GetComponent<FruitMotor>().vel = 2;
        instance.GetComponent<FruitMotor>().score = score;
        instance.transform.position += new Vector3(pos, 6, 0);
    }

    IEnumerator MakeFruit(float rate)
    {
        yield return new WaitForSeconds(rate);
        createFruit();
        StartCoroutine(MakeFruit(difficultyRate));

    }
}
