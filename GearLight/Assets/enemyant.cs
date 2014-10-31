using UnityEngine;
using System.Collections;

public class enemyant : MonoBehaviour {
	public int health;
	//public int damage;
	//public int movementdetectionrange;
	//public int smellrange;
	public GameObject player;
	//public GameObject antqueen;
	//public GameObject antenna;
	public QueenAnt hivestate;
	public float dist;
	public float close = 10.0f;
	public int currentorders = 0;
	public int speed = 10;
	public float turnspeed = 0.1f;
	


	// Use this for initialization
	void Start () {
	
	}
	void OnEnable ()
	{
	player = GameObject.FindWithTag ("player");

		int deviation = Random.Range(-30, 30);
		if(deviation <= 10)
		{
			this.gameObject.tag = "worker";
		}
		else 
		{
			this.gameObject.tag = "soldier";
		}
		health = 100 + deviation;
		int scale = deviation/10;
		this.transform.localScale = new Vector3(scale,scale,scale);
	}
	void Damage()
	{
	//on player attack
	hivestate.hivebehavior = 2;
	}

	// Update is called once per frame
	void Update () 
	{
		dist = Vector3.Distance (this.transform.position, player.transform.position);
		
	// first switch is ant type
	//second is the current hive behavior
	switch (this.gameObject.tag)
	{
		case ("worker"):
			switch (hivestate.hivebehavior)
				{
				case 0:
					//passive behavior
						//find items, bring back to queen
						//remove corpses and trash
						//enter 1 state if see player nearby
						//idle every x seconds
							currentorders = 0;
						if (!Physics.Linecast (this.transform.position, player.transform.position) && dist <= close)
							{
								//can see playernearby
								hivestate.hivebehavior = 1;
							}
					break;
				case 1:
					//caution behavior
						// stare at player and keep distance
						if (!Physics.Linecast (this.transform.position, player.transform.position) && dist <= close++)
							{
								//can see player nearby
								//lookat player
								Vector3 playerpos = hivestate.gameObject.transform.position;
								Quaternion playerrot = Quaternion.LookRotation(playerpos);
								this.transform.rotation = Quaternion.Slerp(this.transform.rotation,playerrot,Time.deltaTime*turnspeed);
											
								//if dist <=? run away and return to looking at player
							}
									
					break;
				case 2:
					//Hostile behavior
						//drop items, attack
					break;
				case 3:
					//panic behavior, smoke
					break;
				}
			break;
		case ("soldier"):
			switch (hivestate.hivebehavior)
			{
			case 0:
				//passive behavior
					//wonder around near queen
					//if see player enter 1 state
					if (!Physics.Linecast (this.transform.position, player.transform.position) && dist <= close)
					{
						//can see player
						hivestate.hivebehavior = 1;
					}
				break;
			case 1:
				//caution behavior
					//stay near queen
					//if player to close enter 2 state
					if (!Physics.Linecast (this.transform.position, player.transform.position) && dist <= close+close)
					{
						//can see player and is close
						hivestate.hivebehavior = 2;
					}
				break;
			case 2:
				//Hostile behavior
					//attack player, dont chase past distance
				break;
			case 3:
				//panic, start smoking
				break;
			}
			break;
		}
	}
	IEnumerator behaviorsubroutines()
	{
	switch(currentorders)
		{
		case 0: //IDLE
			animation.CrossFade("Ant_idle");
			yield return new WaitForSeconds (5);
			currentorders = 1;
			break;
		case 1://find stuff	
			//some kinda finding stuff script
			break;
		case 2://stuff found, move to, pick up
			break;
		case 3: //has stuff return home , drop if home
			//this sets look direction to the queen ant, and lerps to looking at it, then plays the flying animation
			Vector3 returnlocation = hivestate.gameObject.transform.position;
			Quaternion returnrotation = Quaternion.LookRotation(returnlocation);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,returnrotation,Time.deltaTime*turnspeed);
			animation.CrossFade ("Ant_flying");
			//this makes the ant move towards the queen
			this.gameObject.transform.Translate (Vector3.forward * Time.deltaTime * speed);
			break;
		case 4: // hostile, attack player if close, play attack anim
			break;
				
		}

	}
}
