using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	//UI updates
	public Text scoreText;
	public Text time;

	// Use this for initialization
	private float jumpStartTime,jumpTimeLimit=2f;
	private bool isJumping=false;
	private Vector2 startPosition,endPosition;
	private bool isTurnedLeft,isTurnedRight=true;

	//game vars
	private int coinsCollected=0, coinsLeft=18;
	private float gameStartTime,timeLeft=60;
	private bool isGameRunning=true;
	private GameObject doorClosed, doorOpened, levelCompleteTextGO;

	void Start () {
		gameStartTime=Time.time;
		doorClosed=GameObject.FindGameObjectWithTag("doorclosed");
		doorOpened=GameObject.FindGameObjectWithTag("dooropen");
		levelCompleteTextGO=GameObject.FindGameObjectWithTag("levelcomplete");
	}
	
	// Update is called once per frame
	void Update () {

		if(isGameRunning)
		{
			if(Input.GetKey(KeyCode.RightArrow))
			{
				if(isTurnedLeft)
				{
					Vector2 scale = this.transform.localScale;
					scale.x=-scale.x;
					this.transform.localScale=scale;
					isTurnedLeft=false;
				}

				Vector2 position = this.transform.position;
				position.x+=0.1f;
				this.transform.position=position;
				isTurnedRight=true;
			}
			
			if(Input.GetKey(KeyCode.LeftArrow))
			{
				if(isTurnedRight)
				{
					Vector2 scale = this.transform.localScale;
					scale.x=-scale.x;
					this.transform.localScale=scale;
					isTurnedRight=false;
				}
				Vector2 position = this.transform.position;
				position.x-=0.1f;
				this.transform.position=position;
				isTurnedLeft=true;
			}

			if(Input.GetKey(KeyCode.UpArrow) && !isJumping)
			{
				GetComponent<Rigidbody>().AddForce(new Vector2(0,500));
				isJumping=true;
				jumpStartTime=Time.time;
			}

			if(isJumping)
			{
				if( (Time.time - jumpStartTime) > jumpTimeLimit)
				{
					isJumping=false;
				}
			}

			timeCalculate();
		}//isGameRunning

	}

	void timeCalculate()
	{
		if(Time.time - gameStartTime > 1f)
		{
			timeLeft--;
			time.text="Time:"+timeLeft;
			gameStartTime=Time.time;
		}

		if(timeLeft<1)
		{
			isGameRunning=false;

			levelCompleteTextGO.GetComponent<Text>().text="Time Up !";
			levelCompleteTextGO.GetComponent<Text>().enabled=true;
		}
	}

	void OnCollisionEnter(Collision coll) {
		if(coll.gameObject.tag == "coin")
		{

				Debug.Log ("Player collided with coin");
				//scoreText.text="This is test";
				Destroy(coll.gameObject);

				scoreText.text="Score:"+(++coinsCollected);
				coinsLeft--;
				GetComponent<AudioSource>().Play();

			
			if(coinsLeft==0)
			{
				doorClosed.GetComponent<AudioSource>().Play();
				doorClosed.GetComponent<SpriteRenderer>().ensabled=false;
				GetComponent<ShootingEnemy>().isPlayerCollectedAll=true;
				Debug.Log("coins over!");
			}

		}

		if(coll.gameObject.tag == "dooropen")
		{
			levelCompleteTextGO.GetComponent<Text>().enabled=true;
			isGameRunning=false;
			Debug.Log ("Level completed");
		}

		if(coll.gameObject.tag=="enemy" || coll.gameObject.tag=="bullet" )
		{
			if(!GetComponent<ShootingEnemy>().isPlayerCollectedAll)
			{
			levelCompleteTextGO.GetComponent<Text>().text="GAME OVER !";

			levelCompleteTextGO.GetComponent<Text>().enabled=true;

			isGameRunning=false;
			}
		}

		isJumping=false;
	}
}
