using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class metal_collider : MonoBehaviour
{

    private AudioSource aud;

    private void Awake()
    {
        AudioSource aud = GameObject.Find("MetalBang2Sound").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        // Debug.Log("collision enter: " + this.name + "|" + collision.gameObject.name + "|" + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("throw"))
        {
            //Debug.Log("collision go to play MetalBang2Sound");
            //AudioSource aud = GameObject.Find("MetalBang2Sound").GetComponent<AudioSource>();
            aud.PlayOneShot(aud.clip, 0.7F);
        }
    }
}