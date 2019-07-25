using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class MoveToTap : MonoBehaviour
{
    public float DistFromUser = 0.5f;
    public bool SmoothTransition = false;

    Vector3 goalPos;
    Quaternion goalRot;

    ARRaycastManager raycastManager;
    void Start()
    {
        goalPos = this.transform.position;
        goalRot = this.transform.rotation;

        raycastManager = GameObject.Find("AR Session Origin").GetComponent<ARRaycastManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            raycastManager.Raycast(Input.GetTouch(0).position, hits);
            if(hits.Count > 0)
            {
                goalPos = hits[0].pose.position;
            }
            else
            {
                goalPos = Camera.main.transform.position + Camera.main.transform.forward * DistFromUser;
            }
            
            Vector3 toCam = Camera.main.transform.position - goalPos;
            toCam.y = 0f;
            toCam.Normalize();
            goalRot = Quaternion.LookRotation(toCam, Vector3.up);
            if(!SmoothTransition)
            {
                this.transform.position = goalPos;
                this.transform.rotation = goalRot;
            }
        }

        if(SmoothTransition)
        {
            float lerpSpeed = 0.2f;
            this.transform.position = Vector3.Lerp(this.transform.position, goalPos, lerpSpeed);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, goalRot, lerpSpeed);
        }
    }
}
