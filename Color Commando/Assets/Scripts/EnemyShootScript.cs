using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootScript : MonoBehaviour
{
    [SerializeField]
	int shootDelay = 3;
	
	public GameObject projectile;
	public bool isYellow;
	
	GameObject player;
	bool shooted;
	
	// Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
	
	void Shoot() {								
		GameObject p = Instantiate(projectile,	
									transform.position,
									transform.rotation);
		p.GetComponent<EnemyProjectileScript>().colour = GetComponent<MeshRenderer>().material.color;
		p.GetComponent<EnemyProjectileScript>().target = GetComponent<EnemyMovementScript>().target;
		if (isYellow)
			p.GetComponent<EnemyProjectileScript>().speed = 250;
		
		shooted = true;
		Invoke("ResetShoot", shootDelay);
		
	}
	
	void ResetShoot() {
		shooted = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (!shooted)
			Shoot();
    }
}
