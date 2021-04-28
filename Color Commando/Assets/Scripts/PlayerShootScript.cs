﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectileSpawnPos;
    public float speed;
	
	public Transform camera;
	
	private float fracScreenWidth;
    private float widthMinusFrac;
	private int screenHeight;
    private int screenWidth;
	
	bool shooted;
	bool negativeX;
	bool negativeY;
	
	Vector3 forward, backward, up, down;
	
	
	// Start is called before the first frame update
    void Start()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        fracScreenWidth = screenWidth / fracScreenWidth;
        widthMinusFrac = screenWidth - fracScreenWidth;
		
		forward = new Vector3(0, 0, speed);
		backward = new Vector3(0, 0, -speed);
    }
	
	/*void OnMouseDown() {
		Invoke("Shoot", 0);
	}*/
	
	void Shoot() {
		GameObject p = Instantiate(projectile);
		int loopY = (int)(camera.rotation.y / 360);
		int loopX = (int)(camera.rotation.x / 360);
		
		negativeY = loopY < 0 ? true : false;
		negativeX = loopX < 0 ? true : false;
		
		p.transform.position = projectileSpawnPos.transform.position;
		if (Math.Abs(camera.rotation.y) - (360*loopY) <= 180) {
			p.GetComponent<Rigidbody>().velocity = negativeY ? backward : forward;
			/*float vz = p.GetComponent<Rigidbody>().velocity.z;
			up = new Vector3(0, speed, vz);
			down = new Vector3(0, -speed, vz);
			if (Math.Abs(camera.rotation.x) - (360*loopX) <= 180)
				p.GetComponent<Rigidbody>().velocity = negativeX ? down : up;
			else if   
				p.GetComponent<Rigidbody>().velocity = new Vector3(0, speed, vz);*/
		} else {
			p.GetComponent<Rigidbody>().velocity = negativeY ? forward : backward;
			/*float vz = p.GetComponent<Rigidbody>().velocity.z;
			if (camera.rotation.x - (360*loopX) <= 180)
				p.GetComponent<Rigidbody>().velocity = new Vector3(0, -speed, vz);
			else
				p.GetComponent<Rigidbody>().velocity = new Vector3(0, speed, vz);*/
		}			
		shooted = true;
		Invoke("ResetShoot", 1);
		
	}
	
	void ResetShoot() {
		shooted = false;
	}

    // Update is called once per frame
    void Update()
    {
		if (!shooted) {
			if (Input.touchCount > 0) {
				Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero
				if (touch.position.x <= fracScreenWidth)
					if (touch.phase == TouchPhase.Stationary)
						Shoot();
			} else if(Input.GetMouseButton(0)) {
				//Cache mouse position
				Vector2 mouseCache = Input.mousePosition;
				//If mouse x position is less than or equal to a fraction of the screen width
				if (mouseCache.x <= fracScreenWidth)
					Shoot();
			}
		}
				
    }
}
