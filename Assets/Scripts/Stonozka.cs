using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Stonozka : MonoBehaviour
{
    public float speed = 10;
    public System.Action onEatenFood;
    float screenSizeInUnits;
    Vector2 prevDistance = Vector2.zero;
    public BodyPart bodyPartPrefab;

    float halfCurrentObjectWidth;
    
    List<GameObject> bodyPartsList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        halfCurrentObjectWidth = transform.localScale.x / 2f;
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
            AddBodyPart();
            print("Food hit");


        }
    }

    void AddBodyPart() {
        Vector2 spawnPosition = new Vector2(transform.position.x + 2*halfCurrentObjectWidth, transform.position.y);
        BodyPart instance = Instantiate<BodyPart>(bodyPartPrefab, spawnPosition, Quaternion.identity);
        instance.SetFollower(bodyPartsList.Last());
        bodyPartsList.Add(instance.gameObject);
    }
}
