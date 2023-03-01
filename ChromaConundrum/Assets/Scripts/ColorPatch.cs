using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPatch : MonoBehaviour
{
    public Player.ColorBars color;
    public float fireRate = 2f;
    private float change = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        change = Time.time + fireRate;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(Time.time > change)
        {
            change = Time.time + fireRate;
            //print("touching");
            Player.play.fillBar(color);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
