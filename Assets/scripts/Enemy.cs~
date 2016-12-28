using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private float speed=5f;
	private Vector2 currentPosition, currentScale;
	private float enemyStepStartTime,enemyStepTime=1f;
	private bool isRightTurned=true, isLeftTurned=false;

	// Use this for initialization
	void Start () {
		enemyStepStartTime=Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
			currentPosition = transform.position;
			currentPosition.x+=speed*Time.deltaTime;
			transform.position=currentPosition;
	}

	/*
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag=="enemyColliderRedirect" )
		{
				speed=-speed;
				currentScale = transform.localScale;
				currentScale.x=-currentScale.x;
				transform.localScale=currentScale;
		}
	}
	*/

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag=="enemyColliderRedirect" )
		{
			speed=-speed;
			currentScale = transform.localScale;
			currentScale.x=-currentScale.x;
			transform.localScale=currentScale;
		}
	}

}
