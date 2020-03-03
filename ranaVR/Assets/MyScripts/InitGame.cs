using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InitGame : MonoBehaviour
{

    public Vector3 disc1_pos;
    public Quaternion disc1_rot;

    //Awake is always called before any Start functions
    void Awake()
    {

        Debug.Log("Game started ---");
        GameObject g;
        disc1_pos = GameObject.Find("disc_1").transform.position;
        disc1_rot = GameObject.Find("disc_1").transform.rotation;

        
    }

    //Update is called every frame.
    void Update()
    {

    }

    public void ResetPos()
    {
        GameObject.Find("disc_1").transform.position = disc1_pos;
        GameObject.Find("disc_1").transform.rotation = disc1_rot;
    }
}

