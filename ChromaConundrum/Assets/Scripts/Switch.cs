using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public List<Player.ColorBars> reqList = new List<Player.ColorBars>();
    public ColorSwatchObject ColorSwatch;
    public GameObject toggles;
    public Player player;

    private Switch currSwitch;
    private bool toggled;
    private List<SpriteRenderer> barHUD = new List<SpriteRenderer>();
    private int numMet;
    private bool reqMet;

    void Awake()
    {
        toggled = false;
        reqMet = false;
        currSwitch = this;
        for(int i = 0; i < reqList.Count; i++)
        {
            barHUD.Add(currSwitch.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>());

            if (reqList[i] == Player.ColorBars.Red) barHUD[i].color = ColorSwatch.ColorSwatches[0];
            else if (reqList[i] == Player.ColorBars.Blue) barHUD[i].color = ColorSwatch.ColorSwatches[2];
            else if (reqList[i] == Player.ColorBars.Yellow) barHUD[i].color = ColorSwatch.ColorSwatches[1];
        }
    }

    void Update()
    {
        if (reqMet && Input.GetKeyDown(KeyCode.Space))
        {
            print("space key was pressed");
            if (toggled) toggled = false;
            else toggled = true;
            Toggle();
        }
        if (toggled) currSwitch.GetComponent<SpriteRenderer>().color = ColorSwatch.ColorSwatches[9];
        else if (!toggled) currSwitch.GetComponent<SpriteRenderer>().color = ColorSwatch.ColorSwatches[12];
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        bool used;
        numMet = 0;
        foreach (Player.ColorBars color in player.currBar)
        {
            used = false;
            for (int i = 0; i < reqList.Count; i++)
            {
                if (!used && color == reqList[i])
                {
                    numMet++;
                    used = true;
                }
            }
        }
        if (numMet >= reqList.Count) reqMet = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        reqMet = false;
        numMet = 0;
    }

    void Toggle()
    {
        if (toggled)
        {
            toggles.GetComponent<SpriteRenderer>().color = ColorSwatch.ColorSwatches[11];
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), toggles.GetComponent<Collider2D>());
        }
        else
        {
            toggles.GetComponent<SpriteRenderer>().color = ColorSwatch.ColorSwatches[12];
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), toggles.GetComponent<Collider2D>(), false);
        }
        
    }
}
