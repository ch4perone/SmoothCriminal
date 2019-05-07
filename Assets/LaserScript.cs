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
		line.enabled = true;

		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
