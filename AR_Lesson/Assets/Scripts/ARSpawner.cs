using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARSpawner : MonoBehaviour
{
    public GameObject _arObject;
    public GameObject placementIndicator;
    public Pose PlacementPose;
    private bool placementPoseIsValid = false;
    public bool didHit;

    // need to update placement indicator, placement pose and spawn 
    void Update()
    {
        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            didHit = true; // enables walking
        }
        UpdatePlacementIndicator();
    }
    void UpdatePlacementIndicator() // updates target pos with cam movement
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }

    }
}
