using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public Gate currGate;

    void OnTriggerEnter2D(Collider2D col)
    {
        currGate.Open();
    }
    void OnTriggerExit2D(Collider2D col)
    {
        currGate.Close();
    }
}
