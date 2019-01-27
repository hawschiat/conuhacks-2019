using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverController : MonoBehaviour
{
    public GameObject ui;
    public Asteroid asteroid;

    void Start()
    {
        ui.SetActive(false);
    }

    public void setAsteroid(Asteroid obj)
    {
        asteroid = obj;
    }

    void OnMouseOver()
    {
        Time.timeScale = 0.0f;
        ui.GetComponentInChildren<Text>().text = asteroid.print();
        ui.SetActive(true);
    }

    void OnMouseExit()
    {
        Time.timeScale = 1f;
        ui.SetActive(false);
    }
}
