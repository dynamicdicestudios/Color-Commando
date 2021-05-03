using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorClassifier : MonoBehaviour
{
    public string rgbToString(float r, float g, float b) {
		if (r > 1.5f * g && r > 1.5f * b)
			return "red";
		else if (r + g > 2.5f * b && r > b && r > g + 10)
			return "orange";
		else if (r + g > 2.5f * b && r > b)
			return "yellow";
		else if ((g > r || r - g < 10) && g > b)
			return "green";
		else if (b > r && b > g && g > r && Mathf.Abs(b-g) <= 10)
			return "blue";
		else if (r > g && b > g && b > r)
			return "indigo";
		else if (r > g && b > g && r >= b)
			return "violet";
		else if ((r+g+b) < 85*3)
			return "black";
		else if ((r+g+b) >= 85*3)
			return "white";
		else
			return "black";
		
	}
		
}
