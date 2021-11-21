using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    Vector2 screenSizeInUnits;

    // Start is called before the first frame update
    void Start()
    {
        screenSizeInUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, 
        Camera.main.orthographicSize);
        FindObjectOfType<Stonozka> ().onEatenFood += SpanwFood;
        //initial food
        SpanwFood();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void SpanwFood() 
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(-screenSizeInUnits.x,screenSizeInUnits.x), 
            Random.Range(-screenSizeInUnits.y,screenSizeInUnits.y));

        GameObject newFood = (GameObject)Instantiate(foodPrefab, spawnPosition, Quaternion.identity);   
    }
}
