using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public int health;
	public string type;
	public bool isClone;
	public GameObject clone;
	
	string[] types = {"red", "orange", "yellow", "green", 
		"blue", "black", "white"};
	
	bool isBlue;
	bool isRed;
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
		else if (type == types[3])
			Green();
		else if (type == types[4])
			Blue();
		else if (type == types[5])
			Black();
		else if (type == types[6])
			White();
		
    }

    // Update is called once per frame
    void Update()
    {
		if (health <= 0) {
			if (!isClone && isBlue) {
				GameObject c1 = Instantiate(clone,
					new Vector3(gameObject.transform.position.x + 10,
						gameObject.transform.position.y, 
						gameObject.transform.position.z),
					this.gameObject.transform.rotation);
				GameObject c2 = Instantiate(clone,
					new Vector3(gameObject.transform.position.x - 10,
						gameObject.transform.position.y, 
						gameObject.transform.position.z),
					this.gameObject.transform.rotation);
				
				c1.GetComponent<EnemyScript>().isClone = true;
				c2.GetComponent<EnemyScript>().isClone = true;
				
				c1.GetComponent<MeshRenderer>().material.color = GetComponent<MeshRenderer>().material.color;
				c2.GetComponent<MeshRenderer>().material.color = GetComponent<MeshRenderer>().material.color;
			} else if (isRed)
				Explode();
			Destroy(this.gameObject);  
		}
    }
	
	void Red() {
		isRed = true;
	}
	
	void Orange() {
		GetComponent<Light>().color = GetComponent<MeshRenderer>().material.color;
	}
	
	void Yellow() {
		GetComponent<EnemyMovementScript>().speed = 75;
		GetComponent<EnemyShootScript>().isYellow = true;
		
	}
	
	void Green() {
		GetComponent<EnemyShootScript>().isGreen = true;
	}
	
	void Blue() {
		isBlue = true;
	}
	
	void Black() {
		GetComponent<Translate>().enabled = true;
		GetComponent<Translate>().movesHorizontally = false;
	}
	
	void White() {
		GetComponent<Translate>().enabled = true;
		GetComponent<Translate>().movesHorizontally = true;
	}
	
	void Explode() {
		
		
	}
	
	private void OnTriggerEnter(Collider collision) {
		if (collision.CompareTag("Regular")) {
			health -= 1;
			Destroy(collision.gameObject);
		}
		
	}
}
