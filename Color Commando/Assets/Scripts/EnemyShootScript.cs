using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootScript : MonoBehaviour
{
    [SerializeField]
	int shootDelay = 3;
	
	public GameObject projectile;
    public Transform projectileSpawnPosF;
    public Transform projectileSpawnPosB;
	
	GameObject player;
	bool shooted;
	
	// Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
	
	void Shoot() {								
		var heading = player.transform.position - transform.position;
		float dot = Vector3.Dot(heading, transform.forward);
		
		GameObject p = Instantiate(projectile);
		if (dot >= 0) {
			p.transform.position = projectileSpawnPosF.position;
			p.transform.rotation = projectileSpawnPosF.rotation;
			p.GetComponent<EnemyProjectileScript>().isForward = true;
		} else {
			p.transform.position = projectileSpawnPosB.position;
			p.transform.rotation = projectileSpawnPosB.rotation;
			p.GetComponent<EnemyProjectileScript>().isForward = false;
		}
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
