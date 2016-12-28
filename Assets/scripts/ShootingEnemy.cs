using UnityEngine;
using System.Collections;

public class ShootingEnemy : MonoBehaviour {
	
	public GameObject bulletPrefab;
	
	//vars
	private float bulletSpeed=80;
	private float playerX,playerY,bulletX,bulletY;
	private float directionX, directionY;
	private Vector3 bulletDirection, playerPosition, bulletPosition;
	private bool isTargetReached;
	public bool isPlayerCollectedAll;

	//Time vars
	private float timeDelay=5f,bulletTriggerTime;

	// Use this for initialization
	void Start () {
		bulletTriggerTime=Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if(Time.time - bulletTriggerTime > timeDelay && !isPlayerCollectedAll)
		{
			//shoot a bullet
			GameObject bullet;
			bullet = (GameObject)Instantiate(bulletPrefab, this.transform.position,this.transform.rotation);
			bullet.GetComponent<Bullet>().bulletPosition = transform.position;
			bullet.GetComponent<Bullet>().targetPosition = GameObject.FindGameObjectWithTag("player").transform.position;
			bulletTriggerTime=Time.time;
			Debug.Log ("Bullet created");
		}
		//Debug.Log (Time.time - bulletTriggerTime);

	}

}
