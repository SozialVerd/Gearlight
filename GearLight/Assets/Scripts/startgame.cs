﻿using UnityEngine;
using System.Collections;

public class startgame : MonoBehaviour {
	public GameObject classbutton1;
	public GameObject classbutton2;
	public GameObject classbutton3;
	public GameObject gearbutton1;
	public GameObject gearbutton2;
	public GameObject gearbutton3;
	public GameObject startbutton;
	//ler
	public Vector3 from;
	public Vector3 to;
	public GameObject button;
	public Vector3 buttonto;
	public float lerpTime =1.0f;
	public float currentLerpTime;
	public bool goin = false;
	public gear1 gear1;	
	public gear2 gear2;
	public gear3 gear3;
	public Class1 class1;
	public Class2 class2;
	public Class3 class3;
	
	public PlayButton playbutton;
	// Use this for initialization
	void OnEnable () 
	{
		goin = false;	
	}
	
	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0))
		{
			goin = !goin;
			StartCoroutine(gamestart());
		}
	}
	void Update () {
		if (gear1.goin == false && gear2.goin == false && gear3.goin == false)
		{
			goin = true;
			StartCoroutine(disableself());
		}
		if (class1.goin == false && class2.goin == false && class3.goin == false)
		{
			goin = true;
			StartCoroutine(disableself());
		}
		if (playbutton.goin == false)
		{
			goin = true;
			StartCoroutine(disableself());
		}
		if (goin == true )
		{
			slidein();			
		}
		if (goin == false)
		{
			slideout();
		}
	}
	void slidein()
	{
		from = this.transform.position;
		to = new Vector3(this.transform.position.x,this.transform.position.y, -8.2f);
		currentLerpTime = 0;
		
		
		if (currentLerpTime < lerpTime) 
		{
			currentLerpTime += Time.deltaTime;
			if (currentLerpTime > lerpTime) 
			{
				currentLerpTime = lerpTime;
			}
			float perc = currentLerpTime / lerpTime;
			button.transform.position = Vector3.Lerp(from, to, perc);
		}
	}
	
	void slideout()
	{
		from = this.transform.position;
		to = new Vector3(this.transform.position.x,this.transform.position.y, -8.6f);
		currentLerpTime = 0;
		
		
		if (currentLerpTime < lerpTime) 
		{
			currentLerpTime += Time.deltaTime;
			if (currentLerpTime > lerpTime) 
			{
				currentLerpTime = lerpTime;
			}
			float perc = currentLerpTime / lerpTime;
			button.transform.position = Vector3.Lerp(from, to, perc);
		}
	}
	IEnumerator disableself()
	{
		yield return new WaitForSeconds (1);
		this.gameObject.SetActive(false);
	}
	IEnumerator gamestart()
	{
	yield return new WaitForSeconds (2);
	Application.LoadLevel ("dugeon");
	}
}
