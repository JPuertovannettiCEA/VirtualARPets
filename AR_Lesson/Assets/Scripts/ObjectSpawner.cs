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
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        //if raycast hits something that is a AR plane spawn objcet
        /**if(m_ARRaycastManager.Raycast(Input.GetTouch(0).position, hit))
        {
            GameObject clone = Instantiate(m_spawnablePrefab, transform.forward, Quaternion.identity);
        }**/
    }
}
