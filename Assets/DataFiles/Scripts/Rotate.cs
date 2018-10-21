using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    //public float speed = 10f;
    Vector3 movement;
    void Start()
    {
	movement= new Vector3(0,30,0);
    }

    
    void Update ()
    {
        transform.Rotate(movement * Time.deltaTime);
    }
}
