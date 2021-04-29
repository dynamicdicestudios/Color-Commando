using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    [SerializeField]
	float timeTillDestroy = 10;
	
	[SerializeField]
	float speed = 10;
	
	public int face;
	public Color colour;
	
	// Start is called before the first frame update
    void Start()
    {	
		GetComponent<MeshRenderer>().material.color = colour;
	
		if (face == 1)
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
		else if (face == 2)
			GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
		else if (face == 3)
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
        else if (face == 4)
			GetComponent<Rigidbody>().velocity = new Vector3(-speed, 0, 0);
		else if (face == 5)
			GetComponent<Rigidbody>().velocity = new Vector3(0, speed, 0);
		else if (face == 6)
			GetComponent<Rigidbody>().velocity = new Vector3(0, -speed, 0);
		
		
		Destroy(this.gameObject, timeTillDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
