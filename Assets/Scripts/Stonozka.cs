using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stonozka : MonoBehaviour
{
    public float speed = 10;
    public System.Action onEatenFood;
    float screenSizeInUnits;
    Vector2 prevDistance = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        float halfCurrentObjectWidth = transform.localScale.x / 2f;
        screenSizeInUnits = Camera.main.aspect * Camera.main.orthographicSize + halfCurrentObjectWidth;
        transform.Translate(Vector2.zero);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) {
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");
            Vector2 input = new Vector2(inputX, inputY);
            Vector2 direction = input.normalized;
            Vector2 velocity = direction * speed;
            Vector2 distance = velocity * Time.deltaTime;
            prevDistance = distance;
            transform.Translate(distance);
        } else {
            transform.Translate(prevDistance);
        }


        if (transform.position.x < -screenSizeInUnits) {
            transform.position = new Vector2(screenSizeInUnits, transform.position.y);
        }
        if (transform.position.x > screenSizeInUnits) {
            transform.position = new Vector2(-screenSizeInUnits, transform.position.y);
        }

        if (transform.position.y < -screenSizeInUnits) {
            transform.position = new Vector2(transform.position.x, screenSizeInUnits);
        }
        if (transform.position.y > screenSizeInUnits) {
            transform.position = new Vector2(transform.position.x, -screenSizeInUnits);
        }
        
    }

    void OnTriggerEnter2D(Collider2D triggerCollider) 
    {
        if (triggerCollider.tag == "Food") {
            if (onEatenFood != null) {
                //TODO need to diff between food instances
                onEatenFood();
            }
            
            print("Food hit");
        }
    }
}
