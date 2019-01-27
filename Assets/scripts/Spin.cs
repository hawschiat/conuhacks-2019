using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float speed;

    void FixedUpdate()
    {
        transform.Rotate(0, speed, 0);
    }
}
