using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class hole_trigger : MonoBehaviour
{
    public int points;
    private AudioSource aud;

    void Awake()
    {
        AudioSource aud = GameObject.Find("MetalBangSound").GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("throw"))
        {
  
            //AudioSource aud = GameObject.Find("MetalBangSound").GetComponent<AudioSource>();
            aud.PlayOneShot(aud.clip, 0.7F);
          
            GameStatus.AddScore(points);
            Destroy(other.gameObject);
        }

    }

    //void OnTriggerStay(Collider other)
    //{
    //    Debug.Log("Stay");
    //}
    //void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("Exit");
    //}

}
