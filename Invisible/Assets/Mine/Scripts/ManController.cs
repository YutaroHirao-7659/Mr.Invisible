using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManController : MonoBehaviour {

    public Transform player; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(new Vector3(player.position.x,transform.position.y,player.position.z));
	}
}
