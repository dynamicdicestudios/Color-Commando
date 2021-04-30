using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootScript : MonoBehaviour
{
    [SerializeField]
	int shootDelay = 3;
	
	public GameObject projectile;
	
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
