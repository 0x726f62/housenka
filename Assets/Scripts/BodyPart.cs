using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    
    GameObject follow;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (follow != null) {
            //get/set speed
            //get direction
            //move the object
        }
    }

    public void SetFollower(GameObject follow) 
    {
        this.follow = follow;
    }

    
}
