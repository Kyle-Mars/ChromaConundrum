using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static private FollowCam S;
    static public GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        S = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 destination = player.transform.position;
        //destination.x = Mathf.Max(minXY.x, destination.x);
       // destination.y = Mathf.Max(minXY.y, destination.y);
        transform.position = destination;
    }
}
