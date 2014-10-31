using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Movment : MonoBehaviour 
{
	public float speed = 5.0f;
	//public float rotateSpeed = 3.0f;
	//public float curSpeed;
	//	public float gravity = 10.0f;
	//public float jumpHeight = 2.0f;
	//private bool grounded = false;
	float pitch;
	float yaw;
	public GameObject cameraobject;
	public int playerHealth = 10;
	public health agility;
	public GameObject player;

	void Awake ()
	{
		player = GameObject.FindWithTag("Player");
		agility = player.GetComponent<health>();
	}
		
	void Update () 
	{
	
		CharacterController controller = GetComponent<CharacterController>();
		float mouse_dx=Input.GetAxis("Mouse X");
		float mouse_dy=Input.GetAxis("Mouse Y");
		pitch = Mathf.Clamp (pitch-mouse_dy, -90, 90);
		yaw += mouse_dx;
		Vector3 cameraEulerAngles = cameraobject.transform.eulerAngles;
		cameraEulerAngles.x = pitch;
		cameraEulerAngles.y = yaw;
		cameraobject.transform.eulerAngles = cameraEulerAngles;
		
		//moving
		Vector3 bodyEulerAngles = new Vector3 (0, yaw, 0);
		Quaternion bodyRotation = Quaternion.Euler (bodyEulerAngles);
		Vector3 movement = new Vector3 (Input.GetAxis ("Horizontal"),0, Input.GetAxis ("Vertical"));
		//temp var
		float agi=1.0f+agility.agility/100.0f;
//		Debug.Log(agi);
		controller.SimpleMove (bodyRotation* movement*speed*agi);
		if (Input.GetMouseButtonDown(0))
			Screen.lockCursor=true;
			
	}
	void OnEnable()
	{
		Screen.lockCursor=true;
	}
	void OnDisable ()
	{
		Screen.lockCursor=false;
	}
}
