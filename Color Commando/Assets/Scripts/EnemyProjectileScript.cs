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
	public bool isClone;
	public bool isGreen;
	
	GameObject clone;
	
	// Start is called before the first frame update
    void Start()
    {	
		clone = this.gameObject;
		if (!isClone)
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
		
		if (health < 0) {
			if (isGreen && !isClone) {
				GameObject c1 = Instantiate(clone,
					new Vector3(gameObject.transform.position.x + 10,
						gameObject.transform.position.y, 
						gameObject.transform.position.z),
					this.gameObject.transform.rotation);
				GameObject c2 = Instantiate(clone,
					new Vector3(gameObject.transform.position.x - 10,
						gameObject.transform.position.y, 
						gameObject.transform.position.z),
					this.gameObject.transform.rotation);
				
				c1.GetComponent<EnemyProjectileScript>().isClone = true;
				c2.GetComponent<EnemyProjectileScript>().isClone = true;
				
				c1.GetComponent<EnemyProjectileScript>().target = target;
				c2.GetComponent<EnemyProjectileScript>().target = target;
				
				c1.GetComponent<MeshRenderer>().material.color = GetComponent<MeshRenderer>().material.color;
				c2.GetComponent<MeshRenderer>().material.color = GetComponent<MeshRenderer>().material.color;
			}
			Destroy(this.gameObject);
		}
		
	}
}
