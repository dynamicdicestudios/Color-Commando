using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public int health;
	//public float timeToDestroy
    // Start is called before the first frame update
    void Start()
    {
		//Destroy(gameObject, timeToDestroy);
        
    }

    // Update is called once per frame
    void Update()
    {
		if (health <= 0)
			Destroy(this.gameObject);        
    }
	
	private void OnTriggerEnter(Collider collision) {
		if (collision.CompareTag("Regular")) {
			health -= 1;
			Destroy(collision.gameObject);
		}
		
	}
}
