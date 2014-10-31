using UnityEngine;
using System.Collections;

public class testquaternion : MonoBehaviour {
public float w;
public float x;
public float y;
public float z;
	





	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.rotation = new Quaternion(w,x,y,z);
	}
}
