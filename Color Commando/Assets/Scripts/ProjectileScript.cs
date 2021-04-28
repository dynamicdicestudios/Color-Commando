using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField]
	float timeTillDestroy = 10;
	
	[SerializeField]
	float speed = 10;
	
	// Start is called before the first frame update
    void Start()
    {
		GetComponent<Rigidbody>().velocity= Camera.main.transform.forward * speed;
        Destroy(this.gameObject, timeTillDestroy);
    }

    // Update is called once per frame
    void Update() {}
}
