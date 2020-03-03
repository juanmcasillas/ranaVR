﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameStatus : MonoBehaviour
{
    public static GameStatus instance = null;
    public int score = 0;

    private bool button_a_pressed = false;
    private TextMeshProUGUI ui_text;
    private Transform trackingSpace;

    private void Awake()
    {
        if (instance == null) { 
            instance = this;
            instance.ui_text = GameObject.Find("score_text").GetComponent<TextMeshProUGUI>();
            instance.trackingSpace = GameObject.Find("TrackingSpace").GetComponent<Transform>();
        }
        else if (instance != this)
            Destroy(gameObject);
    }



    public static int AddScore(int score)
    {
        instance.score += score;

        //Debug.Log("Score: " + instance.score);
        //TextMeshProUGUI ui_text = GameObject.Find(score_text_label).GetComponent<TextMeshProUGUI>();
        //Debug.Log("Obj: " + ui_text);

        //Debug.Log("Score: " + ui_text.text + "|" + instance.score);
        //ui_text.text = "Score: " + instance.score;
        instance.ui_text.text = instance.score.ToString();
        return instance.score;
    }

    public static int  GetScore()
    {
        return instance.score;
    }


    public void Update()
    {

        OVRInput.Update();

        if (OVRInput.Get(OVRInput.Button.One)) {

            instance.button_a_pressed = true;
            return;
        }
        else
        {
            if (!instance.button_a_pressed)
            {
                return; // button not pressed
            }

            instance.button_a_pressed = false;
            //Debug.Log("Button A has been pressed/released");
            //OVRInput provides touch position and orientation data through GetLocalControllerPosition() and GetLocalControllerRotation(), which return a Vector3 and Quaternion, respectively.
            // require the tracking space
            //Vector3 pos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            //Quaternion rot = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);


            Vector3 pos = instance.trackingSpace.TransformPoint(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch));
            Vector3 rot = instance.trackingSpace.TransformDirection(OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch).eulerAngles);
       
            GameObject coin = (GameObject)Instantiate(Resources.Load("coin"));
            coin.transform.position = pos;
            coin.transform.rotation = Quaternion.Euler(rot);

            // rotate the coin
            Quaternion localRotation = Quaternion.Euler(90, 0f, 0f);
            coin.transform.rotation = coin.transform.rotation * localRotation;

            // toss the coin to upper.

            coin.GetComponent<float_respawn>().start_float();
        }
    }

    public void FixedUpdate()
    {
        OVRInput.FixedUpdate();
    }
}
