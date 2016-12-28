using UnityEngine;
using System.Collections;
/*
 * Set the following vars:
 * Target position, BulletPosition
 * 
 */
public class Bullet : MonoBehaviour {

	public Vector3 targetPosition, bulletPosition;
	private Vector3 bulletDirection;
	private bool isTargetReached;
	private float speed=10;

	// Use this for initialization
	void Start () {
		calculateDirection();
	}
	
	// Update is called once per frame
	void Update () {

		if(bulletPosition == targetPosition)
		{
			Debug.Log ("Target reached");
			///isTargetReached=true;
			Destroy(this);
		}
		
		bulletPosition +=bulletDirection * speed *Time.deltaTime;
		
		transform.position=bulletPosition;
	}

	
	private void calculateDirection()
	{
		bulletDirection = targetPosition-bulletPosition;
		
		if(bulletDirection!=Vector3.zero)
			bulletDirection.Normalize();
		
	}

	void OnCollisionEnter(Collision coll) {
		Debug.Log ("Collided with "+coll.gameObject.tag);
	}
}