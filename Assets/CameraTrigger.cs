using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{

	Light light;
	Color colorDefault;
	bool isScanning;
	float scanningTime;
	float timeToDetect = 1.0f;
	void Start() {
		light = GetComponent<Light>();
		colorDefault = light.color;

	}
	void FixedUpdate() {
		if(isScanning) {		
			scanningTime += Time.deltaTime;
			light.color = Color.Lerp(colorDefault, Color.red, scanningTime / timeToDetect);
			if (scanningTime > timeToDetect) {
				Debug.Log("Detected");
			}
		}
	}

    void OnTriggerEnter(Collider collider) {
		isScanning = true;
		scanningTime = 0;
	}

	void OnTriggerStay(Collider collider)
	{
		//scanningTime += Time.deltaTime;
		//Debug.Log(scanningTime);

		//Debug.Log("Stay");
		//TODO interpolate colorDefault -> RED
	}

	void OnTriggerExit(Collider collider) {
		isScanning = false;	
		light.color = colorDefault;
		scanningTime = 0;
	}
}
