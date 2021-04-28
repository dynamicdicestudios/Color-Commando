using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    [SerializeField]
	float push = -0.0001f;
	
	[SerializeField]
	float maxDist = 5;
	
	public bool movesHorizontally = false;
    
	float startX;
	float startY;
	
	void Start() {
		startX = transform.position.x;
		startY = transform.position.y;		
		
	}	

    // Update is called once per frame
    void Update()
    {
		if (movesHorizontally)
			StartCoroutine(HorizontalTranslate());
		else
			StartCoroutine(VerticalTranslate());
		
    }
	
	IEnumerator HorizontalTranslate() {
		Vector3 pos = transform.position;
		if (pos.x >= startX + maxDist || pos.x <= startX - maxDist)
			push = -push;
		
		pos.x += push;
		transform.position = pos;
		yield return new WaitForSeconds(5f);
	}
	
	IEnumerator VerticalTranslate() {
		Vector3 pos = transform.position;
		if (pos.y >= startY + maxDist || pos.y <= startY - maxDist)
			push = -push;
		
		pos.y += push;
		transform.position = pos;
		yield return new WaitForSeconds(5f);
	}
}
