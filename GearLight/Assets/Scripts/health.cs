using UnityEngine;
using System.Collections;

public class health : MonoBehaviour 

{
public int script1health;
public GameObject[] inventoryslots; //1-10 item slots
public GameObject inventoryholder; // empty object to hold the array
public int activeitem; // currently in use
public GameObject player;
public Texture2D[] icons;
public Texture2D emptyIcon;
public int agility;
public int level = 1;
public int expbase;
public float expleft;
public float mod = 1.15f;
public int currentexp;
public string classname;
public GameObject startingitem;
	
	void levelup()
		{
			float t = Mathf.Pow(mod, level);
			expleft=expbase * t;
			level++;
			currentexp = 0;
		}
	public void gainexp(int exp)
	{
		currentexp += exp;
		if (currentexp >= expleft)
			{
			levelup();

			}
			
	}
	void Start ()
	{
		switch (PlayerPrefs.GetInt("playerclass"))
			{
			case 1:
				agility = 10;
				script1health = 140;
				classname = "tank";
				break;
			case 2:
				agility = 40;
				script1health = 100;
				classname = "average";
				break;
			case 3:
				agility = 80;
				script1health = 60;
				classname = "speedy";
				break;
			}
		switch (PlayerPrefs.GetInt("playerspawnweapon"))
			{
			case 1:
			startingitem.SetActive(true);
			break;

			case 2:
			break;

			case 3:
			break;

			}
	}
	void OnGUI ()
	{
        GUI.Label(new Rect(10, 10, 100, 20), "Health:" +script1health);
		GUI.Label(new Rect(10, 30, 100, 20), "Level:" +level);
		GUI.Label(new Rect(10, 50, 100, 20), currentexp +"/" +expleft);
		GUI.Label(new Rect(10, 70, 100, 20), "Agility:" +agility);
		GUI.Label(new Rect(10, 90 ,100 ,20), classname);

						
		if(activeitem == 1)
		{
			GUI.Label(new Rect(Screen.width-120, Screen.height-120, 50, 50), icons[1]);
			GUI.Label(new Rect(Screen.width-70, Screen.height-70, 50, 50), icons[0]);
		}
 	else
		{
			GUI.Label(new Rect(Screen.width-120, Screen.height-120, 50, 50), icons[0]);
			GUI.Label(new Rect(Screen.width-70, Screen.height-70, 50, 50), icons[1]);
		}
		
	}
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetAxis ("Mouse ScrollWheel") >0) // forward
		{
			activeitem--;
			if(activeitem <0)
			{
				activeitem = inventoryslots.Length-1;//loop
			}
			setcurr();

		
		}
		if (Input.GetAxis ("Mouse ScrollWheel") <0) // back
		{
			activeitem++;
			if(activeitem > inventoryslots.Length -1)
			{
				activeitem = 0;//loop
			}
			setcurr();
		}
		if(script1health <=0)
		{
			script1health=0;
				if (script1health == 0)
					{
						Application.LoadLevel ("levelded");
					}
			
		}
		

	
	}
	
	public void setcurr()
	{ //loops through inv array
		for(int i = 0; i<inventoryslots.Length; i++)
		{//if current 'for loop' inst empty
			if (inventoryslots[i] != null)
			{//deactivate the item
					inventoryslots[i].SetActive(false);
			}
		}
	//if the current slot isnt empty
	if (inventoryslots [activeitem] != null)
		{
		inventoryslots[activeitem].SetActive(true);
		}
	}
}

