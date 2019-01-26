using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NASAController : MonoBehaviour
{
    private const string API_KEY = "rCo1Z0qbjWq1xdKXx2XwLBEYwVv46DF26i0b2vvc";
    private const float API_FETCH_INTERVAL = 10 * 60.0f; //10 minutes
    private float apiCheckCountdown = API_FETCH_INTERVAL;

    void Start()
    {
        FetchAsteroidData();
    }

    // Update is called once per frame
    void Update()
    {
        apiCheckCountdown -= Time.deltaTime;
        if (apiCheckCountdown <= 0)
        {
            FetchAsteroidData();
            apiCheckCountdown = API_FETCH_INTERVAL;
        }
    }

    //Fetch some info about asteroids, store in database?
    private void FetchAsteroidData()
    {
        
    }

}

