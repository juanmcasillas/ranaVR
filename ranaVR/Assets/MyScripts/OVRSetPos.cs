using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OVRSetPos : MonoBehaviour
{
    // Start is called before the first frame update
    protected OVRCameraRig CameraRig = null;

    void Start()
    {

        CameraRig = GameObject.Find("OVRCameraRig").GetComponent<OVRCameraRig>();
        //CameraRig.UpdatedAnchors += UpdateTransform;


        //CameraRig.trackingSpace.localRotation = Quaternion.Euler(Vector3.up * 180.0f);
        //CameraRig.trackingSpace.localPosition += new Vector3(0.49f, 10.0f, -8.7f);

        //CameraRig.transform.localRotation = Quaternion.Euler(Vector3.up * 180.0f);
        //CameraRig.transform.localPosition = CameraRig.transform.InverseTransformPoint(new Vector3(0.49f, 0.0f, -8.7f));
        // CameraRig.transform.localPosition = new Vector3(0.49f, 0.0f, -8.7f);

        //Transform t = GameObject.Find("OVRCameraRig").GetComponent<Transform>();
        //t.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
        //UnityEngine.XR.InputTracking.Recenter();
        // transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
        //OVRManager.instance.headPoseRelativeOffsetRotation = new Vector3(0, 180, 0);
        //OVRManager.instance.headPoseRelativeOffsetTranslation = new Vector3(1.0f, 0.0f, 1.0f);
    }

    public void Update()
    {
        //CameraRig.trackingSpace.localPosition += new Vector3(-0.1f, 0.0f, 0.0f);

    }
    public void UpdateTransform(OVRCameraRig rig)
    {
        Transform root = CameraRig.trackingSpace;
        Transform centerEye = CameraRig.centerEyeAnchor;
        /*
        if (false)
        {
            Vector3 prevPos = root.position;
            Quaternion prevRot = root.rotation;

            transform.rotation = Quaternion.Euler(0.0f, centerEye.rotation.eulerAngles.y, 0.0f);

            root.position = prevPos;
            root.rotation = prevRot;
        }
        */
    }
}
