using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{

	float cameraTurningSpeed = 0.9f;
	float upperAngle = 0.025f;
	float lowerAngle = 0.075f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if(Input.GetAxis("Mouse Y") > 0.0f && transform.rotation.x > -upperAngle)  {
			transform.Rotate(cameraTurningSpeed * -Input.GetAxis("Mouse Y"), 0, 0);
		}
		if(Input.GetAxis("Mouse Y") < 0.0f && transform.rotation.x < lowerAngle)  {
			transform.Rotate(cameraTurningSpeed * -Input.GetAxis("Mouse Y"), 0, 0);
		}
   		
    }

	public void OnGUI()
    {
		Rect x = new Rect(10,10,100,100);
		GUI.Label(x, transform.rotation.x.ToString());
 			
	}
}
