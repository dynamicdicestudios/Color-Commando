using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    [SerializeField]
	float intensityMax = 8;
	
	Light light;
	
    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        light.intensity = Mathf.PingPong(Time.time, intensityMax);
    }
}
