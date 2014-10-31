using UnityEngine;
using System.Collections;

public class DedScreen : MonoBehaviour {
public Texture2D uded;

	// Use this for initialization
	void Start () {
	audio.Play();
	}
	
	void OnGUI ()
	{
		GUI.Label(new Rect(Screen.width/2-250, Screen.height/2-250, 500, 500), uded);

	}
	// Update is called once per frame
	void Update () {
	
	}
}
