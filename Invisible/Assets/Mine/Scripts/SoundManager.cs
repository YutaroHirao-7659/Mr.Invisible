using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public List<AudioSource> soundEffects;

    public float timeToNock = 3;
    public float timeToWindowbreak = 7;
    public float timeToWalk = 5;

    private bool isCoroutine = false;

    public GameObject player;
    public GameObject walkingSound;
    public float walkingCircleRadius = 1;
    public float reWalkDistance = 1.3f;
    public float moveSpeed = 0.5f;
    private float walkAroundSpeed = 30;

    private Animator manAnimation;
    public GameObject invisibleMan;

    private soundState currentState;
    enum soundState
    {
        NOCK,
        BREAK,
        WALK,
        WAIT,
        NONE,
        NUM
    }

	// Use this for initialization
	void Start () {
        currentState = soundState.NOCK;
        manAnimation = invisibleMan.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (currentState)
        {
            case soundState.NOCK:
                if (!isCoroutine)
                {
                    StartCoroutine("Nock");
                    isCoroutine = true;
                }
                else if(!soundEffects[0].isPlaying)
                {
                    currentState = soundState.BREAK;
                    isCoroutine = false;
                }
                break;
            case soundState.BREAK:
                if (!isCoroutine)
                {
                    StartCoroutine("Break");
                    isCoroutine = true;
                }
                else if (!soundEffects[1].isPlaying)
                {
                    currentState = soundState.WALK;
                    isCoroutine = false;
                }
                break;
            case soundState.WALK:
                var soundPosition = new Vector2(walkingSound.transform.position.x, walkingSound.transform.position.z);
                var playerPosition = new Vector2(player.transform.position.x, player.transform.position.z);
                if (Vector2.Distance(soundPosition, playerPosition) > reWalkDistance)
                {
                    if (!soundEffects[2].isPlaying)
                    {
                        soundEffects[2].Play();
                        invisibleMan.SetActive(true);
                        manAnimation.SetBool("isWalk", true);
                    }
                    var tempPosition = Vector3.Lerp(walkingSound.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
                    walkingSound.transform.position = new Vector3(tempPosition.x, walkingSound.transform.position.y, tempPosition.z);
                }
                else if(Vector2.Distance(soundPosition, playerPosition) <= walkingCircleRadius)
                {
                    if (soundEffects[2].isPlaying)
                    {
                        soundEffects[2].Stop();
                        manAnimation.SetBool("isWalk", false);
                        invisibleMan.SetActive(false);
                    }

                    if (!soundEffects[3].isPlaying)
                    {
                        int rnd = Random.Range(0, 180);
                        if(rnd == 1)
                        {
                            soundEffects[3].Play();
                        }
                    }
                }
                break;
            default:
                break;
        }
	}

    IEnumerator Nock()
    {
        currentState = soundState.WAIT;
        yield return new WaitForSeconds(timeToNock);
        soundEffects[0].Play();
        currentState = soundState.NOCK;
    }

    IEnumerator Break()
    {
        currentState = soundState.WAIT;
        yield return new WaitForSeconds(timeToWindowbreak);
        soundEffects[1].Play();
        currentState = soundState.BREAK;
    }

    IEnumerator Walk()
    {
        currentState = soundState.WAIT;
        yield return new WaitForSeconds(timeToWalk);
        soundEffects[2].Play();
        currentState = soundState.WALK;
    }
}
