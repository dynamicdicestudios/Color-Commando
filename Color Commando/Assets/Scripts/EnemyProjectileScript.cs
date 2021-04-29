using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    [SerializeField]
	float timeTillDestroy = 10;
	
	[SerializeField]
	float speed = 10;
	
	public bool isForward;
	
	// Start is called before the first frame update
    void Start()
    {	
		if (isForward)
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
		else
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
        Destroy(this.gameObject, timeTillDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
