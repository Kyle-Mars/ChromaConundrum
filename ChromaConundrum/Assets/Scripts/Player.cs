using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum ColorBars
    {
        Red,
        Blue,
        Yellow,
        Clear
    }

    static public Player play;
    public ColorSwatchObject ColorSwatch;
    public GameObject bar1;
    public GameObject bar2;
    public GameObject bar3;
    public float stepDist = 4f;

    private List<ColorBars> colorBar = new List<ColorBars>();
    public List<ColorBars> currBar => colorBar;
    private List<SpriteRenderer> barHUD = new List<SpriteRenderer>();
    private int barFill = 0;
    private bool full = false;
    private SpriteRenderer charRend;
    private Rigidbody2D coll;

    void Awake()
    {
        play = this;
        coll = play.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        charRend = GetComponent<SpriteRenderer>();
        barHUD.Add(bar1.GetComponent<SpriteRenderer>());
        barHUD.Add(bar2.GetComponent<SpriteRenderer>());
        barHUD.Add(bar3.GetComponent<SpriteRenderer>());
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        coll.velocity =  stepDist * moveInput;

        if(full) changeColor();
    }

    public void fillBar(ColorBars color)
    {
        if(barFill < 3 && color != ColorBars.Clear)
        {
            colorBar.Add(color);
            barFill++;
            print("add" + color);
            if (color == ColorBars.Red) barHUD[barFill - 1].color = ColorSwatch.ColorSwatches[0];
            if (color == ColorBars.Yellow) barHUD[barFill - 1].color = ColorSwatch.ColorSwatches[1];
            if (color == ColorBars.Blue) barHUD[barFill - 1].color = ColorSwatch.ColorSwatches[2];
            if (barFill == 3) full = true;
        }

        else if(color == ColorBars.Clear)
        {
            ClearBar();
        }
    }

    private void changeColor()
    {
        if (colorBar.Count<ColorBars>(x => x == ColorBars.Red) == 3) charRend.color = ColorSwatch.ColorSwatches[0];
        if (colorBar.Count<ColorBars>(x => x == ColorBars.Yellow) == 3) charRend.color = ColorSwatch.ColorSwatches[1];
        if (colorBar.Count<ColorBars>(x => x == ColorBars.Blue) == 3) charRend.color = ColorSwatch.ColorSwatches[2];
        if (colorBar.Count<ColorBars>(x => x == ColorBars.Red) == 2 && colorBar.Count<ColorBars>(x => x == ColorBars.Yellow) == 1) charRend.color = ColorSwatch.ColorSwatches[6];
        if (colorBar.Count<ColorBars>(x => x == ColorBars.Red) == 1 && colorBar.Count<ColorBars>(x => x == ColorBars.Yellow) == 2) charRend.color = ColorSwatch.ColorSwatches[5];
        if (colorBar.Count<ColorBars>(x => x == ColorBars.Red) == 2 && colorBar.Count<ColorBars>(x => x == ColorBars.Blue) == 1) charRend.color = ColorSwatch.ColorSwatches[7];
        if (colorBar.Count<ColorBars>(x => x == ColorBars.Red) == 1 && colorBar.Count<ColorBars>(x => x == ColorBars.Blue) == 2) charRend.color = ColorSwatch.ColorSwatches[8];
        if (colorBar.Count<ColorBars>(x => x == ColorBars.Yellow) == 2 && colorBar.Count<ColorBars>(x => x == ColorBars.Blue) == 1) charRend.color = ColorSwatch.ColorSwatches[4];
        if (colorBar.Count<ColorBars>(x => x == ColorBars.Yellow) == 1 && colorBar.Count<ColorBars>(x => x == ColorBars.Blue) == 2) charRend.color = ColorSwatch.ColorSwatches[3];
        if (colorBar.Count<ColorBars>(x => x == ColorBars.Yellow) == 1 && colorBar.Count<ColorBars>(x => x == ColorBars.Blue) == 1 && colorBar.Count<ColorBars>(x => x == ColorBars.Red)  == 1 ) charRend.color = ColorSwatch.ColorSwatches[9];
    }

    public void ClearBar()
    {
        colorBar.Clear();
        barFill = 0;
        print("Cleared the bar");
        charRend.color = ColorSwatch.ColorSwatches[10];
        barHUD[0].color = ColorSwatch.ColorSwatches[11];
        barHUD[1].color = ColorSwatch.ColorSwatches[11];
        barHUD[2].color = ColorSwatch.ColorSwatches[11];
        full = false;
    }
}
