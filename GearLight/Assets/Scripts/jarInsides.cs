using UnityEngine;
using System.Collections;

public class jarInsides : MonoBehaviour {
	
	//all possible effects
	public Effect[] effects;
	//effect of this potion
	public Effect thiseffect = new Effect();
	
	//color vars(0.5 cause thats exactly middle gray)
	public float r = 0.5F;
	public float g = 0.5F;
	public float b = 0.5F;
	
	//the struct of effects that contains a name and an amount
	[System.Serializable]
	public struct Effect
	{
		public string Name;
		public float Amount;
	}
	
	//on awake
	void Awake()
	{
		//generate a random number
		int rnd = Random.Range(0,2);
		//generate another random number	
		float rnd2 = Random.Range(0F,1.0F);
		
		
		//create new color variable
		Color color = new Color(r, g, b, 1F);
		
		
		//based on rnd, choose one of your possible effects
		switch(rnd)
		{
		case  0:
			//set the effect of this potion to one of the possible ones
			thiseffect = effects[0];
			//change the related color component to the strength
			color.r = rnd2;
			break;
			
		case 1:
			thiseffect = effects[1];
			color.g = rnd2;
			break;
			
		case 2:
			thiseffect = effects[2];
			color.b = rnd2;
			break;
		}
		
		//set your amount of the effect
		thiseffect.Amount = rnd2;
		//assign the color to the object
		renderer.material.color = color;
	}
}