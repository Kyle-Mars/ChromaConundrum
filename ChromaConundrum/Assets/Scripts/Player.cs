using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum ColorBars
    {
        Red,
        Blue,
        Yellow
    }

    static public Player play;
    private List<ColorBars> colorBar = new List<ColorBars>();
    private int barFill = 0;
    private bool full = false;
    public float stepDist = 4f;
    SpriteRenderer rend;

    private Rigidbody2D coll;
    // Start is called before the first frame update
    void Awake()
    {
        play = this;
        coll = play.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        coll.velocity =  stepDist * moveInput;

        changeColor();
    }

    public void fillBar(ColorBars color)
    {
        if(barFill < 3)
        {
            colorBar.Add(color);
            barFill++;
            print("add red");
        }
    }

    private void changeColor()
    {
        if(colorBar.Count > 2 && !full)
        {
            rend.color = Color.red;
            full = true;
        }
                
    }
}
