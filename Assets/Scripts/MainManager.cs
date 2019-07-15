using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Text timeRemaining;
    public Text points;
    public Canvas gameCanvas;
    public Canvas gameOver;
    public Canvas winCanvas;
 
    public string undeadSelected;
    public int gameTime;
    public int gamePoints;
    public int winningPoints;
    public bool timesUp = false;
    private GameObject undeaded;

    private void Start()
    {
        InvokeRepeating(nameof(Timer), 0.0000001f, 1.0f);

    }
    private void Update()
    {
        timeRemaining.text = gameTime.ToString();
        points.text = gamePoints.ToString();

        if (gamePoints >= winningPoints)
        {
            gameCanvas.enabled = false;
            winCanvas.enabled = true;
        }
        if (timesUp)
        {
            gameCanvas.enabled = false;
            gameOver.enabled = true;
        }
    }

    private void Timer()
    {
        if (gameTime > 1)
        {
            gameTime--;
        }
        else
        {
            timesUp = true;
        }
    }

}
