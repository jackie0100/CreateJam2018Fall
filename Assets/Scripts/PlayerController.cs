using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 dir = new Vector3(Input.GetAxis("horizontal"), 0, Input.GetAxis("vertical")).normalized;

        
	}
}
