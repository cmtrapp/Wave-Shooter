using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    RaycastHit hit;
    int dist = 100;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.DrawRay(transform.position, transform.forward * dist, Color.blue);
		if (Physics.Raycast(transform.position, transform.forward, out hit, dist))
        {
            Debug.Log("mepp");
        }
	}
}
