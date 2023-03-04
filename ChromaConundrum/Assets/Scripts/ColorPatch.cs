using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPatch : MonoBehaviour
{
    public Player.ColorBars color;
    public float fillRate = 1f;
    private float fullTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        fullTime = Time.time + fillRate;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(Time.time > fullTime)
        {
            fullTime = Time.time + fillRate;
            Player.play.fillBar(color);
        }
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
