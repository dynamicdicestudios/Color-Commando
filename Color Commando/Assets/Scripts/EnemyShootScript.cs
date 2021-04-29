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
		
		if (dot >= 0) {
			GameObject p = Instantiate(projectile,
								projectileSpawnPosF.position,
								projectileSpawnPosF.rotation);
			p.GetComponent<EnemyProjectileScript>().isForward = true;
		} else {
			GameObject p = Instantiate(projectile,
								projectileSpawnPosB.position,
								projectileSpawnPosB.rotation);
			p.GetComponent<EnemyProjectileScript>().isForward = true;
		}
			
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
