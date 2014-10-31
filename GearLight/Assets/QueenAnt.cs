using UnityEngine;
using System.Collections;

public class QueenAnt : MonoBehaviour {
public int hivebehavior = 0;
public int health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (health == 0)
		{
		hivebehavior = 3;
		}
	}
}
//0 default passive
//1 alert, soldiers move to within x of queen
//2 player attacks ants, colony is hostile
//3 panic
//each ant type takes imput seperately