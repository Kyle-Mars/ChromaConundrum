using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public List<Player.ColorBars> reqList = new List<Player.ColorBars>();
    public ColorSwatchObject ColorSwatch;
    public Player player;

    private Gate currGate;
    private List<SpriteRenderer> barHUD = new List<SpriteRenderer>();
    private int numMet;
    private bool reqMet;

    void Awake()
    {
        //Add color bar requirements to the gate.
        reqMet = false;
        currGate = this;
        for (int i = 0; i < reqList.Count; i++)
        {
            barHUD.Add(currGate.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>());

            //Set color of each bar.
            if (reqList[i] == Player.ColorBars.Red) barHUD[i].color = ColorSwatch.ColorSwatches[0];
            else if (reqList[i] == Player.ColorBars.Blue) barHUD[i].color = ColorSwatch.ColorSwatches[2];
            else if (reqList[i] == Player.ColorBars.Yellow) barHUD[i].color = ColorSwatch.ColorSwatches[1];
        }
    }

    void Update()
    {
        //Check if the gate needs to be opened, ignore collision if so. 
        if(reqMet)
        {
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), currGate.GetComponent<Collider2D>());
        }
        else Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), currGate.GetComponent<Collider2D>(), false);
    }

    public void Open()
    {
        //Compare color bar of gate with color bar of Player. 
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

    public void Close()
    {
        //Reset gate status.
        reqMet = false;
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), currGate.GetComponent<Collider2D>(), false);
        numMet = 0;
    }
}
