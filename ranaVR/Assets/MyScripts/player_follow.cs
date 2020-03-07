using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_follow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform t = GameObject.Find("CenterEyeAnchor").GetComponent<Transform>();
        transform.position = new Vector3(t.position.x, 0, t.position.z);

        //transform.position = Vector3.MoveTowards(transform.position, t.transform.position, .03f);
    }
}
