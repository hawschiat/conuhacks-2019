using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NASAController : MonoBehaviour
{
    private const string API_KEY = "rCo1Z0qbjWq1xdKXx2XwLBEYwVv46DF26i0b2vvc";
    private const float API_FETCH_INTERVAL = 10 * 60.0f; //10 minutes
    private float apiCheckCountdown = API_FETCH_INTERVAL;

    public string startDate;
    public string endDate;

    void Start()
    {
        Debug.Log("I'm alive!");
        StartCoroutine(FetchAsteroidData());
    }

    // Update is called once per frame
    void Update()
    {
        apiCheckCountdown -= Time.deltaTime;
        if (apiCheckCountdown <= 0)
        {
            StartCoroutine(FetchAsteroidData());
            apiCheckCountdown = API_FETCH_INTERVAL;
        }
    }

    //Fetch some info about asteroids, store in database?
    private IEnumerator FetchAsteroidData()
    {
        UnityWebRequest request = UnityWebRequest.Get(
            System.String.Format("https://api.nasa.gov/neo/rest/v1/feed?start_date={0}&end_date={1}&api_key={2}",
                                 startDate, endDate, API_KEY));
        yield return request.SendWebRequest();

        if (request.isHttpError) Debug.LogError("Error: " + request.error);
        else Debug.Log(request.downloadHandler.text);
    }

}

