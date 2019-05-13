using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider collider) {
		Debug.Log("Enter");
	}

	void OnTriggerStay(Collider collider) {
		Debug.Log("Stay");
	}

	void OnTriggerExit(Collider collider) {
		Debug.Log("Exit");
	}
}
