using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start () {

        rb.velocity = transform.forward * speed;
    }
	
 
}
