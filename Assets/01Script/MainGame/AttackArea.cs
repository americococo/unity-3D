using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //message

    public void Enable()
    {
        GetComponent<Collider>().enabled = true;
    }
    public void disable()
    {
        GetComponent<Collider>().enabled = false;
    }
}
