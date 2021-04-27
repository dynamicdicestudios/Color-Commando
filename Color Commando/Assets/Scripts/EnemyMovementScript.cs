using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public Transform target;
	
	[SerializeField]
	float speed = 5;
	
	//[SerializeField]
	//float haltDist = 200;
	
	//int direction;
	
	System.Random rnd = new System.Random();
	
	// Start is called before the first frame update
    void Start()
    {
        /*direction = rnd.Next(-1, 1);
		if (direction > -1)
			GetComponent<Translate>().movesHorizontally = true;
		else
			GetComponent<Translate>().movesHorizontally = false;*/
    }

    // Update is called once per frame
    void Update()
    {
		/*if (Vector3.Distance(transform.position, target.position) < haltDist)
			GetComponent<Translate>().enabled = true;
		else {*/
		// Move our position a step closer to the target.
		float step =  speed * Time.deltaTime; // calculate distance to move
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		//}
		
	}
}
