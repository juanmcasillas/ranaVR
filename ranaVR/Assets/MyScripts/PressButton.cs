using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{

    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void YouPressedMe()
    {
        //audio.Play();
        audio.PlayOneShot(audio.clip, 0.5F);
        Debug.Log("button Pressed");
        //InitGame n = GameObject.Find("manager").GetComponent<InitGame>();
        //n.ResetPos();

        GameObject disc = (GameObject)Instantiate(Resources.Load("disc"));
        disc.transform.position = new Vector3((float)-1.749, (float)1.418, (float)0.307);
        disc.transform.rotation = new Quaternion(0, 0, 0, 0);

    }
}
