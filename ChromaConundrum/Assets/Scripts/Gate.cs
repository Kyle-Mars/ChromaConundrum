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
        reqMet = false;
        currGate = this;
        for (int i = 0; i < reqList.Count; i++)
        {
            barHUD.Add(currGate.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>());

            if (reqList[i] == Player.ColorBars.Red) barHUD[i].color = ColorSwatch.ColorSwatches[0];
            else if (reqList[i] == Player.ColorBars.Blue) barHUD[i].color = ColorSwatch.ColorSwatches[2];
            else if (reqList[i] == Player.ColorBars.Yellow) barHUD[i].color = ColorSwatch.ColorSwatches[1];
        }
    }

    void Update()
    {
        if(reqMet)
        {
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), currGate.GetComponent<Collider2D>());
        }
        else Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), currGate.GetComponent<Collider2D>(), false);
    }

    public void Open()
    {
        int used = -1;
        numMet = 0;
        foreach (Player.ColorBars color in player.currBar)
        {
            for (int i = 0; i < reqList.Count; i++)
            {
                if (used != i && color == reqList[i])
                {
                    numMet++;
                    used = i + 1;
                }
            }
        }
        if (numMet >= reqList.Count) reqMet = true;
    }

    public void Close()
    {
        reqMet = false;
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), currGate.GetComponent<Collider2D>(), false);
        numMet = 0;
    }
}
