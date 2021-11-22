using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Stonozka> ().onEatenFood += beEaten;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void beEaten() {
            Destroy(gameObject);
            FindObjectOfType<Stonozka> ().onEatenFood -= beEaten;
    }
}
