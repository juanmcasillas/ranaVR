using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellTrigger : MonoBehaviour
{

    public AudioSource audio_cube;
    public AudioSource audio_disc;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        Debug.Log("tag: " + other.tag);

        AudioSource audio = audio_disc;

        if (other.CompareTag("cube"))
        {
            audio = audio_cube;           
        }

        audio.PlayOneShot(audio.clip, 0.5F);

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
