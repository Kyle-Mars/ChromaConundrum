using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button: MonoBehaviour
{
    public List<Player.ColorBars> reqList = new List<Player.ColorBars>();
    public ColorSwatchObject ColorSwatch;
    public GameObject toggles;
    public Player player;

    private Button currButton;
    private List<SpriteRenderer> barHUD = new List<SpriteRenderer>();
    private int numMet;
    private bool reqMet;

    void Awake()
    {
        reqMet = false;
        currButton = this;
        for(int i = 0; i < reqList.Count; i++)
        {
            barHUD.Add(currButton.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>());

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
            currButton.GetComponent<SpriteRenderer>().color = ColorSwatch.ColorSwatches[9];
            player.ClearBar();
            Toggle();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        int used = -1;
        numMet = 0;
        foreach (Player.ColorBars color in player.currBar)
        {
            for(int i = 0; i < reqList.Count;i++)
            {
                if(used != i && color == reqList[i])
                {
                    numMet++;
                    used = i + 1;
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
        toggles.GetComponent<SpriteRenderer>().color = ColorSwatch.ColorSwatches[11];
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), toggles.GetComponent<Collider2D>());
    }
}
