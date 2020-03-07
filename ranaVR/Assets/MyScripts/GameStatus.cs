using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using VRTK.Prefabs.Locomotion.Teleporters;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    public static GameStatus instance = null;
    public int score = 0;
    public int coins = 6;

    private bool button_a_pressed = false;
    private bool button_b_pressed = false;

    private TextMeshProUGUI score_text;
    private TextMeshProUGUI coins_text;

    private Transform trackingSpace;

    private OVRCameraRig cameraRig;

    private void Awake()
    {
        if (instance == null) { 
            instance = this;
            instance.score_text = GameObject.Find("score_text").GetComponent<TextMeshProUGUI>();
            instance.coins_text = GameObject.Find("coins_text").GetComponent<TextMeshProUGUI>();
            instance.trackingSpace = GameObject.Find("TrackingSpace").GetComponent<Transform>();
            instance.cameraRig = GameObject.Find("OVRCameraRig").GetComponent<OVRCameraRig>();
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    public void Start()
    {

        //Debug.Log("To the center");
        TeleporterFacade f = GameObject.Find("Teleporter.Instant").GetComponent<TeleporterFacade>();
        f.ApplyDestinationRotation = true;
        GameObject emptyGO = new GameObject();
        //emptyGO.transform.position = new Vector3(3.1f, 0.25f, -2.525f);
        //emptyGO.transform.position = GameObject.Find("BaseR").GetComponent<Transform>().position + new Vector3(0.0f, 1.0f, 0.0f);

        Transform point_to = GameObject.Find("BaseC").GetComponent<Transform>();
        emptyGO.transform.position = point_to.position + new Vector3(0.0f, point_to.localScale.y, 0.0f);
        emptyGO.transform.LookAt(GameObject.Find("FrogBox").GetComponent<Transform>());


        Zinnia.Data.Type.TransformData d = new Zinnia.Data.Type.TransformData(emptyGO.transform);
        f.Teleport(d);
        f.ApplyDestinationRotation = false;

        // init the TV :D
        instance.coins_text.text = instance.coins.ToString();
        instance.score_text.text = instance.score.ToString();
    }

    public static int AddScore(int score)
    {
        instance.score += score;

        //Debug.Log("Score: " + instance.score);
        //TextMeshProUGUI ui_text = GameObject.Find(score_text_label).GetComponent<TextMeshProUGUI>();
        //Debug.Log("Obj: " + ui_text);

        //Debug.Log("Score: " + ui_text.text + "|" + instance.score);
        //ui_text.text = "Score: " + instance.score;
        instance.score_text.text = instance.score.ToString();
        return instance.score;
    }

    public static int  GetScore()
    {
        return instance.score;
    }

    public static int RemoveCoin(int coins=1)
    {
        instance.coins -= coins;
        instance.coins_text.text = instance.coins.ToString();
        return instance.coins;
    }

    public void Update()
    {

        //Transform mgr = GameObject.Find("OVRPos").GetComponent<Transform>();
        //Vector3 posX;
        //Vector3 delta = new Vector3(1.0f, 0.0f, 0.0f);
        //posX = mgr.localToWorldMatrix.MultiplyPoint(UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye));
        //mgr.position = posX + delta;
        //UnityEngine.XR.InputTracking.disablePositionalTracking = true;


        OVRInput.Update();

        // tooltips
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            GameObject.Find("OculusTouchForQuestAndRiftS_Right").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("ControllerTooltips").GetComponent<VRTK.VRTK_ControllerTooltips>().ToggleTips(true);
            GameObject.Find("ControllerTooltips").GetComponent<VRTK.VRTK_ControllerTooltips>().ToggleTips(false, VRTK.VRTK_ControllerTooltips.TooltipButtons.StartMenuTooltip);
            GameObject.Find("ControllerTooltips").GetComponent<VRTK.VRTK_ControllerTooltips>().ToggleTips(false, VRTK.VRTK_ControllerTooltips.TooltipButtons.TouchpadTwoTooltip);
        }
        else
        {
            GameObject.Find("OculusTouchForQuestAndRiftS_Right").GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("ControllerTooltips").GetComponent<VRTK.VRTK_ControllerTooltips>().ToggleTips(false);
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft))
        {

            //UnityEngine.XR.InputTracking.disablePositionalTracking = true;
            //TextMeshProUGUI ui_text = GameObject.Find(score_text_label).GetComponent<TextMeshProUGUI>();
            // Debug.Log("To the right");
            TeleporterFacade f = GameObject.Find("Teleporter.Instant").GetComponent<TeleporterFacade>();
            f.ApplyDestinationRotation = true;
            GameObject emptyGO = new GameObject();
            //emptyGO.transform.position = new Vector3(3.1f, 0.25f, -2.525f);
            //emptyGO.transform.position = GameObject.Find("BaseR").GetComponent<Transform>().position + new Vector3(0.0f, 1.0f, 0.0f);

            Transform point_to = GameObject.Find("BaseL").GetComponent<Transform>();
            emptyGO.transform.position = point_to.position + new Vector3(0.0f, point_to.localScale.y, 0.0f);
            emptyGO.transform.LookAt(GameObject.Find("FrogBox").GetComponent<Transform>());


            Zinnia.Data.Type.TransformData d = new Zinnia.Data.Type.TransformData(emptyGO.transform);
            f.Teleport(d);
            f.ApplyDestinationRotation = false;

            //GameObject.Find("DD").transform.position = instance.cameraRig.centerEyeAnchor.position;
            //GameObject.Find("XX").transform.position = emptyGO.transform.position;
            /*
            Debug.Log("To the left");
            Camera CameraRig = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();
            CameraRig.transform.localRotation = Quaternion.Euler(CameraRig.transform.localRotation.eulerAngles -(Vector3.up * 20.0f));
            */
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight))
        {
            //Debug.Log("To the left");
            TeleporterFacade f = GameObject.Find("Teleporter.Instant").GetComponent<TeleporterFacade>();
            f.ApplyDestinationRotation = true;
            GameObject emptyGO = new GameObject();
            Transform point_to = GameObject.Find("BaseR").GetComponent<Transform>();
            emptyGO.transform.position = point_to.position + new Vector3(0.0f, point_to.localScale.y, 0.0f);
            emptyGO.transform.LookAt(GameObject.Find("FrogBox").GetComponent<Transform>());

            // not needed to set the layer, but the HEIGHT right.
            //emptyGO.layer = LayerMask.NameToLayer("Teleportable");
            //emptyGO.layer = 10;

            Zinnia.Data.Type.TransformData d = new Zinnia.Data.Type.TransformData(emptyGO.transform);
            f.Teleport(d);
            f.ApplyDestinationRotation = false;

            // debug positions
            //GameObject.Find("DD").transform.position = instance.cameraRig.centerEyeAnchor.position;
            //GameObject.Find("XX").transform.position = emptyGO.transform.position;

            /*
            Debug.Log("to the right");
            Camera CameraRig = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();
            CameraRig.transform.localRotation = Quaternion.Euler(CameraRig.transform.localRotation.eulerAngles + (Vector3.up * 20.0f));
            */
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown))
        {
            //Debug.Log("To the back");
            TeleporterFacade f = GameObject.Find("Teleporter.Instant").GetComponent<TeleporterFacade>();
            f.ApplyDestinationRotation = true;
            GameObject emptyGO = new GameObject();
            Transform point_to = GameObject.Find("BaseC").GetComponent<Transform>();
            emptyGO.transform.position = point_to.position + new Vector3(0.0f, point_to.localScale.y, 0.0f);
            emptyGO.transform.LookAt(GameObject.Find("FrogBox").GetComponent<Transform>());


            Zinnia.Data.Type.TransformData d = new Zinnia.Data.Type.TransformData(emptyGO.transform);
            f.Teleport(d);
            f.ApplyDestinationRotation = false;
        }


        // B button. Go to main menu
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            instance.button_b_pressed = true;
        }
        else
        {
            if (instance.button_b_pressed)
            {
                instance.button_b_pressed = false;
                SceneManager.LoadScene("Main_Menu");

            }
        }


        // A button. Create some coins here

        if (OVRInput.Get(OVRInput.Button.One))
        {

            instance.button_a_pressed = true;
        }
        else
        {
            if (instance.button_a_pressed)
            {
                instance.button_a_pressed = false;

                if (RemoveCoin() < 0)
                {
                    // go to game over.
                    SceneManager.LoadScene("Main_Menu");
                }

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
    }

    public void FixedUpdate()
    {
        OVRInput.FixedUpdate();
    }




}
