using UnityEngine;
using System.Collections;

public class Pooler : MonoBehaviour {
public GameObject[] pool = null;
public bool playeragression = false;
	void Awake () 
	{
		this.gameObject.tag = "antpool";
	}
}