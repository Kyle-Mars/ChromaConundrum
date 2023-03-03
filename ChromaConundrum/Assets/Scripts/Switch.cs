using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public List<Player.ColorBars> reqList = new List<Player.ColorBars>();
    public ColorSwatchObject ColorSwatch;
    public Player player;

    private Switch currSwitch;
    private List<SpriteRenderer> barHUD = new List<SpriteRenderer>();
    private int numMet;
    private bool reqMet;

    // Start is called before the first frame update
    void Awake()
    {
        reqMet = false;
        currSwitch = this;
        for(int i = 0; i < reqList.Count; i++)
        {
            barHUD.Add(currSwitch.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>());

            for (i = 0; i < reqList.Count; i++)
            {
                if (reqList[i] == Player.ColorBars.Red) barHUD[i].color = ColorSwatch.ColorSwatches[0];
                if (reqList[i] == Player.ColorBars.Blue) barHUD[i].color = ColorSwatch.ColorSwatches[2];
                if (reqList[i] == Player.ColorBars.Yellow) barHUD[i].color = ColorSwatch.ColorSwatches[1];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (reqMet && Input.GetKeyDown(KeyCode.Space))
        {
            print("space key was pressed");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        int used = -1;
        numMet = 0;
        foreach (Player.ColorBars color in player.currBar)
        {
            for(int i = 0;i < reqList.Count;i++)
            {
                if(used != i && color == reqList[i])
                {
                    numMet++;
                    used = i;
                }
            }
        }
        if (numMet == reqList.Count) reqMet = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        reqMet = false;
        numMet = 0;
    }
}
