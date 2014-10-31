using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {
public GameObject classbutton1;
public GameObject classbutton2;
public GameObject classbutton3;
public GameObject gearbutton1;
public GameObject gearbutton2;
public GameObject gearbutton3;
public GameObject startbutton;


	public Vector3 from;
	public Vector3 to;
	//public float lerpovertime = 1.0f;
	public GameObject button;
	public Vector3 buttonto;
	public float lerpTime =1.0f;
	public float currentLerpTime;
	public bool goin = false;

	

	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0))
		{
			goin = !goin;
				if (goin == true)
				{
				classbutton1.SetActive(true);
				classbutton2.SetActive(true);
				classbutton3.SetActive(true);	
				}
		}
			//this.gameObject.SetActive(false);		
	}
		

	void Update()
	{
		if (goin == true)
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
}
