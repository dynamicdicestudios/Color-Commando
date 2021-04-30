using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    [SerializeField]
	float timeTillDestroy = 10;
	
	[SerializeField]
	float speed = 10;
	
	public Color colour;
	public Transform target;
	
	// Start is called before the first frame update
    void Start()
    {	
		GetComponent<MeshRenderer>().material.color = colour;
		target = GetComponent<EnemyMovementScript>().target;
		Destroy(this.gameObject, timeTillDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
		float step =  speed * Time.deltaTime; // calculate distance to move
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
