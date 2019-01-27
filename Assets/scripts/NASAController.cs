using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;

public class Asteroid
{
    
    public string name { get; set; }
    public string estimatedDiameter { get; set; }
    public bool isPHA {get; set;}
    public string closeApproachDate { get; set; }
    public double missDistance { get; set; }
    public string orbitingBody { get; set; }
    public double velocity { get; set; }
    
}

public class NASAController : MonoBehaviour
{
    private const string API_KEY = "rCo1Z0qbjWq1xdKXx2XwLBEYwVv46DF26i0b2vvc";
    private const float API_FETCH_INTERVAL = 10 * 60.0f; //10 minutes
    private float apiCheckCountdown = API_FETCH_INTERVAL;

    public string startDate;
    public string endDate;

    void Start()
    {
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

        if (request.isHttpError)
        {
            Debug.LogError("Error: " + request.error);
            yield break;
        }

        List<Asteroid> asteroids = new List<Asteroid>();
        JObject results = JObject.Parse(request.downloadHandler.text);
        JEnumerable<JToken> dates = results["near_earth_objects"].Children();

        foreach (JToken date in dates)
        {
           foreach(JToken seoList in date.Children())
            {
                foreach(JToken seo in seoList)
                {
                    Debug.Log("SEO" + seo);
                    Asteroid closeAsteroid = new Asteroid
                    {
                        name = (string)seo["name"],
                        estimatedDiameter = seo["estimated_diameter"]["meters"]["estimated_diameter_min"] +
                                                    " - " + seo["estimated_diameter"]["kilometers"]["estimated_diameter_max"],
                        isPHA = (bool)seo["is_potentially_hazardous_asteroid"],
                        closeApproachDate = (string)seo["close_approach_data"][0]["close_approach_date"],
                        missDistance = (double)seo["close_approach_data"][0]["miss_distance"]["kilometers"],
                        orbitingBody = (string)seo["close_approach_data"][0]["orbiting_body"],
                        velocity = (double)seo["close_approach_data"][0]["relative_velocity"]["kilometers_per_hour"]
                    };
                    asteroids.Add(closeAsteroid);
                }
                
            }
        }
        
        foreach(Asteroid a in asteroids)
        {
            
        }

    }

}

