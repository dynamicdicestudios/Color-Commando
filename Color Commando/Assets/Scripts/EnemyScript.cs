using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public int health;
	public string[] types = {"red", "orange", "yellow", "green",
		"blue", "indigo", "violet", "black", "white"};
	public string type;
	//public float timeToDestroy
    // Start is called before the first frame update
    void Start()
    {
		//Destroy(gameObject, timeToDestroy);
		if (type == types[0])
			Red();
		else if (type == types[1])
			Orange();
		else if (type == types[2])
			Yellow();
		
    }

    // Update is called once per frame
    void Update()
    {
		if (health <= 0)
			Destroy(this.gameObject);        
    }
	
	void Red() {
		
	}
	
	void Orange() {
		GetComponent<Translate>().enabled = true;
		GetComponent<Translate>().movesHorizontally = true;
	}
	
	void Yellow() {
		GetComponent<EnemyMovementScript>().speed = 75;
		
	}
	
	private void OnTriggerEnter(Collider collision) {
		if (collision.CompareTag("Regular")) {
			health -= 1;
			Destroy(collision.gameObject);
		}
		
	}
}
