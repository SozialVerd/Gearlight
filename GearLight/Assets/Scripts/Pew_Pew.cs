using UnityEngine;
using System.Collections;
 
public class Pew_Pew : MonoBehaviour {
        public GameObject player;
        public health inventory;
        public caster raycaster;
        public int isHeld = 0;
        public int cooldown=10;
        public int gundamange=1;
        public Texture2D icon;
		public int guncooldown;
		public int guncooldownmax;
        //the text that is displayed on mouseover
        public string infotext = "Colt";
//function that gets called on mouseover
        void info(caster a)
        {
                //set the infotext and reset the counter
                a.information = infotext;
                a.textcounter = a.textmax;
        }
       
        void Awake ()
        {
                player = GameObject.FindWithTag("Player");
                inventory = player.GetComponent<health>();
                raycaster = player.GetComponentInChildren <caster>();  
        }
		void FixedUpdate()
		{
		     //limits firerate 
			 // if cooldown loer than max cooldown
				 if (guncooldown < guncooldownmax - inventory.agility)
                {
                        guncooldown++;
				}
				 if (cooldown > 0)
                {
                        cooldown--;
                }
		}
        void Update ()
        {  
            //fixes shooting on pickup
               
                if (isHeld== 1 && cooldown==0)
                {	
				//temp var
				int cd = guncooldownmax-inventory.agility;
				//if lower than 0 set to 0
				if (cd<0)
				{
					cd=0;
				}
				
                        if(Input.GetMouseButtonDown(0) && guncooldown>=cd)
                        {
                                audio.Play();
                                //calls the damage function on the caster
                                //gun calls caster script
                                raycaster.Damage(gundamange);
								guncooldown= 0;
								
                        }
                }
        }
        // Use this for initialization
        void Start () {
               
        }
        void hit()
        {
                cooldown=10;
                for(int i = 0; i < inventory.inventoryslots.Length; i++)
                {
                        if (inventory.inventoryslots[i] == null)
                        {
                                rigidbody.isKinematic = true;
                                transform.parent = inventory.inventoryholder.transform;
                                transform.position = inventory.inventoryholder.transform.position;
                                transform.eulerAngles = transform.parent.eulerAngles;
                               
                                inventory.inventoryslots[i] = gameObject;
                               
                                inventory.activeitem = i;
                                inventory.icons[i] = icon;
								inventory.setcurr();
                               
                                isHeld = 1;
                               
                                break;
                        }
                }
        }
       
        // Update is called once per frame
       
}