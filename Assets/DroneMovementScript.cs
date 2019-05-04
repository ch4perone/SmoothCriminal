using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovementScript : MonoBehaviour
{
	Rigidbody thisDrone;
	float levitationForce;
	private float speedAcceleration = 150.0f;
	private float speedMaximum = 2.0f;
	private float turningSpeed = 2.0f;
	private float desiredRotation;
	private float currentRotation;
	private float rotateAmountByKeys = 1.5f;
	private float rotationYVelocity;
	private Vector3 refVelocityDamping;
	private Vector3 refRotationDamping;
	//TODO add tilt (at least sidewards)	


    // Start is called before the first frame update
    void Start()
    {
        thisDrone = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        levitate();
		moveForward();
		rotate();
		thisDrone.AddRelativeForce(Vector3.up * levitationForce);
		/*thisDrone.rotation = Quaternion.Euler(
				new Vector3(thisDrone.rotation.x, currentRotation, thisDrone.rotation.z)
			);*/

		boundSpeed();
    }

	void levitate() {
		if(Input.GetKey(KeyCode.Space)) {
			levitationForce = 180;
		} else if(Input.GetKey(KeyCode.LeftShift)) {
			levitationForce = 98.1f; //98.1f; //10kg * 9.81f
		} else {
			levitationForce = 90; // Falling with force - gravity (98.1f)
		}
	}

	void moveForward() {
		if(Input.GetAxis("Vertical") != 0) {
			thisDrone.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * speedAcceleration);
		}
	}

	void rotate() {
		/*if(Input.GetKey(KeyCode.A)) {
			desiredRotation -= rotateAmountByKeys;
		}
		else if(Input.GetKey(KeyCode.D)) {
			desiredRotation += rotateAmountByKeys;
		}

		currentRotation = Mathf.SmoothDamp(currentRotation, desiredRotation, ref rotationYVelocity, 0.25f);*/
		//currentRotation = Mathf.SmoothDamp(currentRotation, turningSpeed * Input.GetAxis("Mouse X"), ref rotationYVelocity, 0.25f);
		thisDrone.transform.Rotate(0, turningSpeed * Input.GetAxis("Mouse X"), 0);
	}

	void boundSpeed() {
		if(Mathf.Abs(Input.GetAxis("Vertical")) > 0.02f) { //Mathf.Abs(Input.GetAxis("Horizontal")) > 0.02f
			thisDrone.velocity = Vector3.ClampMagnitude(thisDrone.velocity, Mathf.Lerp(thisDrone.velocity.magnitude, speedMaximum, Time.deltaTime * 5.0f)); 
		}
		else if(Mathf.Abs(Input.GetAxis("Vertical")) < 0.02f){
			thisDrone.velocity = Vector3.SmoothDamp(thisDrone.velocity, Vector3.zero, ref refVelocityDamping, 0.95f); 
		}
		if(Mathf.Abs(Input.GetAxis("Horizontal")) < 0.02f) {
			/*thisDrone.rotation = Quaternion.Euler(
				new Vector3(thisDrone.rotation.x, Vector3.SmoothDamp(thisDrone.rotation.y, Vector3.zero, ref  refRotationDamping, 0.95f), thisDrone.rotation.z)
			);*/
		}
	}
}
