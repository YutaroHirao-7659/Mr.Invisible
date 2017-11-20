using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAround : MonoBehaviour {

    private AudioSource walkSound;

    public GameObject player;

    public float walkingCircleRadius = 1;
    public float moveSpeed = 0.5f;
    private float walkAroundSpeed = 30;


	// Use this for initialization
	void Start () {
        walkSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (walkSound.isPlaying)
        {
            var soundPosition = new Vector2(transform.position.x, transform.position.z);
            var playerPosition = new Vector2(player.transform.position.x, player.transform.position.z);
            if(Vector2.Distance(soundPosition,playerPosition) > walkingCircleRadius)
            {
                var tempPosition = Vector3.Lerp(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
                transform.position = new Vector3(tempPosition.x, transform.position.y, tempPosition.z);
            }
            /*else
            {
                transform.RotateAround(player.transform.position,Vector3.up, walkAroundSpeed * Time.deltaTime);
            }
            */
        }
	}
}
