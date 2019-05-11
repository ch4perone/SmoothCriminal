using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

	LineRenderer line;
	
    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
		line.material.color = Color.red;
		line.enabled = true;

		
    }

    // Update is called once per frame
    void Update()
    {
		
		Ray ray = new Ray(transform.position, transform.forward);
		line.SetPosition(0, ray.origin);        		
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 200)) {
			line.SetPosition(1, hit.point);
			if(hit.collider.name == "DroneParent") {
				//TODO loose life or whatever
				#if UNITY_EDITOR
					 UnityEditor.EditorApplication.isPlaying = false;
			 	#else
					 Application.Quit();
			 	#endif
			}
		}
		else {
			line.SetPosition(1, ray.GetPoint(200));
		}
    }
}
