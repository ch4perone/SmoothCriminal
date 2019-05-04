using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

	public float bulletForce = 4000.0f;
	 

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * bulletForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
