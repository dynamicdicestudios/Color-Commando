using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	[SerializeField]
    int health = 5;
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnTriggerEnter(Collider collision) {
		if (collision.CompareTag("EnemyProjectile")) {
			health -= 1;
			Destroy(collision.gameObject);
		}
		
		/*if (health < 0)
			Debug.Log("You Lose");*/
		
	}
}
