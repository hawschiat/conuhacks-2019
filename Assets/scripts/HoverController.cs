using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverController : MonoBehaviour
{
    public HoverData hd;

    public void startHover(HoverData hd)
    {
        this.hd = hd;
    }

    void Start()
    {
        hd.ui.SetActive(false);
    }

    void OnMouseOver()
    {
        Time.timeScale = 0.3f;
        hd.ui.GetComponent<Text>().text = hd.asteroid.print();
        hd.ui.SetActive(true);
    }

    void OnMouseExit()
    {
        Time.timeScale = 1f;
        hd.ui.SetActive(false);
    }
}

public class HoverData
{
    public GameObject ui;
    public Asteroid asteroid;

    public HoverData(GameObject ui, Asteroid a)
    {
        this.ui = ui;
        this.asteroid = a;
    }
}
