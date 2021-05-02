using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
	public MarklessAR markless;
	[SerializeField]
	float spawnDist;
	
	[SerializeField]
	float spawnDelay = 2;
	
	public bool isArcade;
	public ColorClassifier cc;
	
	private WebCamTexture backCam;	 
	System.Random rnd = new System.Random();
	
	float zCoor;
	bool hasSpawned;	
	int height, width;
	
	// Start is called before the first frame update
    void Start()
    {
		zCoor = transform.position.z + spawnDist;
		width = Screen.width;
        height = Screen.height;
		
		if (isArcade)
			backCam = markless.backCam;
    }

    // Update is called once per frame
    void Update()
    {		
		if (!hasSpawned) {
			hasSpawned = true;
			if (isArcade)
				ArcadeSpawnEnemy();
			else
				StartCoroutine(ClassicSpawnEnemy());
		}
	}
	
	void ResetSpawn() {
		hasSpawned = false;
	}
	
	
	void ArcadeSpawnEnemy() {
		float x = UnityEngine.Random.value;
		float y = UnityEngine.Random.value;
		
		//Vector3 spawnPos = new Vector3(x, y, zCoor);
		Vector3 spawnPos = Camera.main.ViewportToWorldPoint(new Vector3(x, y, spawnDist));
		
		Color colour = backCam.GetPixel((int)(spawnPos.x), (int)(spawnPos.y));
		string name = cc.rgbToString(colour.r, colour.g, colour.b);
		Debug.Log(name); 
		
		
		GameObject player = GameObject.FindWithTag("Player");
		GameObject foe = Instantiate(enemy, spawnPos, transform.rotation);
		foe.GetComponent<EnemyMovementScript>().target = player.transform;
		foe.GetComponent<MeshRenderer>().material.color = colour;
		
		Invoke("ResetSpawn", spawnDelay);
		
	}
	
	IEnumerator ClassicSpawnEnemy() {
		yield return new WaitForEndOfFrame();

        // Create a texture the size of the screen, RGB24 format
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
		
		float x = UnityEngine.Random.value;
		float y = UnityEngine.Random.value;
		
		//Vector3 spawnPos = new Vector3(x, y, zCoor);
		Vector3 spawnPos = Camera.main.ViewportToWorldPoint(new Vector3(x, y, spawnDist));
		
		Color colour = tex.GetPixel((int)(spawnPos.x), (int)(spawnPos.y));
		string name = cc.rgbToString(Mathf.round(colour.r*255),
									Mathf.round(colour.g*255),
									Mathf.round(colour.b*255));
		Debug.Log(name);
		if (name == "black")
			Debug.Log(colour.r);
		
		GameObject player = GameObject.FindWithTag("Player");
		GameObject foe = Instantiate(enemy, spawnPos, transform.rotation);
		foe.GetComponent<EnemyMovementScript>().target = player.transform;
		foe.GetComponent<MeshRenderer>().material.color = colour;
	
		Invoke("ResetSpawn", spawnDelay);
	}
	
}
