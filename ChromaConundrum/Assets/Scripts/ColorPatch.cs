using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPatch : MonoBehaviour
{
    public Player.ColorBars color;
    public float fillRate = 1f;
    private float fullTime;

    //Begin filling Player's color bar.
    void OnTriggerEnter2D(Collider2D col)
    {
        fullTime = Time.time + fillRate;
    }

    //Fill Player's color bar in increments.
    void OnTriggerStay2D(Collider2D col)
    {
        if(Time.time > fullTime)
        {
            fullTime = Time.time + fillRate;
            Player.play.fillBar(color);
        }
    }
}
