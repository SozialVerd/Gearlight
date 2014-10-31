using UnityEngine;
using System.Collections;

public class LOD : MonoBehaviour 
{
	//array of high poly gameobjects
	public GameObject[] meshes;
	//distance at which the LOD triggers
	public float maxDist = 10.0f;
	
	public float dist;
	private bool highpoly = true;
	private GameObject player;
	

	void Awake () 
	{
		player = GameObject.FindWithTag("Player");
	}
	
	void Update () 
	{
		dist = Vector3.Distance(player.transform.position, transform.position);
		//if player is close, enable highpoly
		if(dist >= maxDist)
		{
			//if already enabled
			if(highpoly == true)
			{
				//do nothing
			}
			else
			{
				//disable high poly
				disable();
				highpoly = !highpoly;
			}
		}
		//else, disable high poly
		else
		{	
			//if already disabled
			if(highpoly == false)
			{

			}
			else
			{
				enable();
				highpoly = !highpoly;
			}
		}
	}
	
	void disable()
	{
		foreach(GameObject a in meshes)
		{
			a.SetActive (false);
		}
	}
	
	void enable()
	{
		foreach(GameObject b in meshes)
		{
			b.SetActive (true);
		}
	}
}
