using UnityEngine;
using System.Collections;

public class menudebugger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	PlayerPrefs.SetInt ("playerclass", 0);
	PlayerPrefs.SetInt ("playerspawnweapon",0);
	}
	
	// Update is called once per frame
	void Update () {
	Debug.Log("class"+PlayerPrefs.GetInt("playerclass"));
	Debug.Log("weap"+PlayerPrefs.GetInt("playerspawnweapon"));

	}
}
