using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class float_respawn : MonoBehaviour
{

    private float timer = 0.0f;
    private float max_floating = 0.4f;
    private bool floating = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        if (floating) {
            Rigidbody rigid = GetComponent<Rigidbody>();
            timer += Time.deltaTime;
            //float seconds = (timer % 60);            
            if (timer > max_floating)
            {
                  
                rigid.AddForce(Physics.gravity, ForceMode.Acceleration); // avoid gravity
                floating = false;
            }
            else
            {
                
                rigid.AddForce(-Physics.gravity, ForceMode.Acceleration); // avoid gravity
            }
        }
    }

    public void start_float()
    {
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.AddForce(-Physics.gravity * (rigid.mass), ForceMode.Force); // toss up!
        floating = true;
    }
}
