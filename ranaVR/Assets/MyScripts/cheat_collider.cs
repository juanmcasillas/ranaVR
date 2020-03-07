using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cheat_collider: MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        //Debug.LogWarning("collision enter: " + this.name + "|" + other.gameObject.name + "|" + other.gameObject.tag);

        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("collision go to play MetalBang2Sound");
            //AudioSource aud = GameObject.Find("MetalBang2Sound").GetComponent<AudioSource>();
            SceneManager.LoadScene("Main_Menu");
        }
    }
}
