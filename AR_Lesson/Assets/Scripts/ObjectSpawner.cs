using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private ARRaycastManager m_ARRaycastManager;
    
    [SerializeField]
    private Camera m_camera;

    [SerializeField]
    private GameObject m_spawnablePrefab;

    //public LayerMask Layer;

    // Update is called once per frame
    void Update()
    {
        //Create a raycast
        Vector2 screenPos = m_camera.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        m_ARRaycastManager.Raycast(screenPos, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if(hits.Count > 0 && Input.GetMouseButtonDown(0))
        {
            var hitPose = hits[0].pose;
            Instantiate(m_spawnablePrefab, hitPose.position, hitPose.rotation);
        }
    }
}
