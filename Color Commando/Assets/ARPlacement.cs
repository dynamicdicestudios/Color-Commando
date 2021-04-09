using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARPlacement : MonoBehaviour
{
    
	public GameObject arSpawnObject;
	public GameObject placementIndicator;
	
	private spawnedObject;
	private Pose PlacementPose;
	private ARRaycastManager arRaycastManager;
	private bool placementPoseIsValid = false;
	
	
	// Start is called before the first frame update
    void Start()
    {
        arRaycastManager = FindObjecyOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
		UpdatePlacementIndicator();
    }
	
	void UpdatePlacementIndicator() {
		if(spawnedObject == null && placementPoseIsValid) {
			placementIndicator.SetActive(true);
			placementIndicator.transform.SetPositionAndRotation(PlacementPose.position,
				PlacementPose.rotation);
		} else {
			placementIndicator.SetActive(false);
		}
		
	}	
}
