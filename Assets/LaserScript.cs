using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

	public bool isMoving;
	Vector3 startingPosition;
	public Vector3 movementVector;
	public float movementDuration;

	LineRenderer line;
	
    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
		line.material.color = Color.red;
		line.enabled = true;
		startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		if(isMoving) {
			move();
		}
		Ray ray = new Ray(transform.position, transform.forward);
		line.SetPosition(0, ray.origin);        		
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 200)) {
			line.SetPosition(1, hit.point);
			if(hit.collider.name == "DroneParent") {
				//TODO loose life or whatever
				Debug.Log("Detected");
			}
		}
		else {
			line.SetPosition(1, ray.GetPoint(200));
		}
    }

	void move() {
		float movementOffset = Mathf.PingPong(Time.time, movementDuration) / movementDuration;
		transform.position = new Vector3(startingPosition.x + movementOffset * movementVector.x, startingPosition.y + movementOffset * movementVector.y, startingPosition.z + movementOffset * movementVector.z); 
	}

}
