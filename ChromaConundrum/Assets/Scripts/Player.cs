using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player play;
    public float stepDist = 4f;

    private Rigidbody2D coll;
    // Start is called before the first frame update
    void Awake()
    {
        play = this;
        coll = play.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //transform.Translate(moveInput * stepDist * Time.deltaTime);

        coll.velocity =  stepDist * moveInput;
    }
}
