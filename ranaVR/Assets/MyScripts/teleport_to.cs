using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Prefabs.Locomotion.Teleporters;

public class teleport_to: MonoBehaviour
{
    public GameObject lookatobject;
    public GameObject teleportlocation;
    private bool first_time = true;
    void Start()
    {

    }

    private void Update()
    {
        if (first_time) { 
            TeleporterFacade f = GameObject.Find("Teleporter.Instant").GetComponent<TeleporterFacade>();
            GameObject emptyGO = new GameObject();

            f.ApplyDestinationRotation = true;
            emptyGO.transform.position = teleportlocation.transform.position;
            emptyGO.transform.LookAt(lookatobject.GetComponent<Transform>());
            Zinnia.Data.Type.TransformData d = new Zinnia.Data.Type.TransformData(emptyGO.transform);
            f.Teleport(d);
            f.ApplyDestinationRotation = false;
            first_time = false;
        }
    }

}
