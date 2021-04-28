using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarklessAR : MonoBehaviour
{
	//Gyro
    //private Gyroscope gyro;
	private GameObject cameraContainer;
	private Quaternion rot;
	
	//Camera
	[SerializeField]
	bool usingCamera;
	[HideInInspector]
	public WebCamTexture backCam;	
	public RawImage background;
	public AspectRatioFitter fit;
	
	private bool arReady = false;
	public GameObject gyroConfirm;
	
	public Joystick joystick;
	public float rotationSpeed;
	
	Vector3 eulerAngleVelocity;
	Rigidbody rigidBody;
	
	// Start is called before the first frame update
    void Start()
    {
		WebCamDevice[] devices = WebCamTexture.devices;
		rigidBody = GetComponent<Rigidbody>();
		rigidBody.constraints = RigidbodyConstraints.FreezeRotationZ;
		
        //Check if we support both services
		/*if (!SystemInfo.supportsGyroscope) {
			Debug.Log("This device does not have a gyroscope");
			gyroConfirm.SetActive(true);
			//return;
		}*/
		
		if (devices.Length == 0) {
			Debug.Log("No available Camera");
			return;		
		}
		
		//Back Camera
		for (int i = 0; i < devices.Length; i++) {
			//ALWAYS REMEMBER TO ADD ! WHEN BUILDING 
			if (devices[i].isFrontFacing)
				backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);			
		}
		
		if (backCam == null) {
			Debug.Log("No available Camera");
			return;
		}
		
		//Both sevices are supported, so enable them!
		/*cameraContainer = new GameObject("Camera Container");
		cameraContainer.transform.position = transform.position;
		transform.SetParent(cameraContainer.transform);*/
		
		//gyro = Input.gyro;
		//gyro.enabled = true;
		//cameraContainer.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
		rot = new Quaternion(0, 0, 1, 0);
		
		if (usingCamera) {
			backCam.Play();
			background.texture = backCam;
		}

		arReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (arReady) {
			//Update Camera
			float ratio = (float)backCam.width / (float)backCam.height;
			fit.aspectRatio = ratio;
			
			float scaleY = backCam.videoVerticallyMirrored ? -1f: 1f;
			background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);
			
			int orient = -backCam.videoRotationAngle;
			background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
			
			Debug.Log(joystick.Horizontal);
			Debug.Log(joystick.Vertical);
			
			/*transform.RotateAround(transform.position, Vector3.up,
				rotationSpeed * joystick.Horizontal * Time.deltaTime);*/
			
			Quaternion localRotation = Quaternion.Euler(-joystick.Vertical,
											joystick.Horizontal, 0f);
			transform.rotation = transform.rotation * localRotation;
				//transform.RotateAround(transform.position, Vector3.left,
					//rotationSpeed * joystick.Vertical * Time.deltaTime);
			
			//Update Gyroscope
			//transform.localRotation = gyro.attitude * rot;
			
		}
		
		void FixedUpdate() {
			/*eulerAngleVelocity = new Vector3(0,
				joystick.Horizontal * rotationSpeed,
				joystick.Vertical * rotationSpeed);
				
			Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.fixedDeltaTime);
			rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);*/
			
		}
    }
}
