using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    [SerializeField]
	float timeTillDestroy = 10;
	
	public float speed = 10;
	
	[SerializeField]
	int health = 0;
	
	public Color colour;
	public Transform target;
	
	// Start is called before the first frame update
    void Start()
    {	
		GetComponent<MeshRenderer>().material.color = colour;
		Destroy(this.gameObject, timeTillDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
		float step =  speed * Time.deltaTime; // calculate distance to move
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
	
	private void OnTriggerEnter(Collider collision) {
		if (collision.CompareTag("Regular"))
			health -= 1;
		
		if (health < 0)
			Destroy(this.gameObject);
		
	}
}
