using UnityEngine;
using System.Collections;

public class test1 : MonoBehaviour {
[System.Serializable]
public struct entry
{
public string name;
public int number;
}
public entry[] phonebook;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	Debug.Log(phonebook[1].number);
	}
}
