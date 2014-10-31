using UnityEngine;
using System.Collections;

public class RandomItem : MonoBehaviour {
	
	public GameObject[] prefabs;
	public int vRandom;
	
	public void Awake()
	{
		vRandom = Random.Range(0, prefabs.Length);
		Instantiate(prefabs[vRandom], transform.position, transform.rotation);
		Destroy(gameObject);
	}
}