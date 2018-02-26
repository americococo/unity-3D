using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    //message
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
    }


    public void Enable()
    {
        GetComponent<Collider>().enabled = true;
    }
    public void disable()
    {
        GetComponent<Collider>().enabled = false;
    }
}
