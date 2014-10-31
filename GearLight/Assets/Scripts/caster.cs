using UnityEngine;
using System.Collections;
 
public class caster : MonoBehaviour {
 
        public float distance = 100.0f;
        public Transform enemy;
        public Texture2D textureToDisplay;
        public int health;
        private int count;
       
        //info variables
        //info countdown
        public int textcounter;
        //info count max
        public int textmax = 10;
        //info string
        public string information;
 
        void hit ()
        {
                health=health-1;
        }
        // Use this for initialization
        void OnGUI ()
        {
                GUI.Label(new Rect(Screen.width/2, Screen.height/2, 10, 10), textureToDisplay);
                        //if counter was reset, display text
                        if(textcounter > 0)
                        {
                                GUI.Label(new Rect(Screen.width/2-50, Screen.height/2, 100, 20), information);
                        }
        }
       
        // Update is called once per frame
        //does no damage
        void Update ()
        {
                if(Input.GetMouseButtonDown(0))
                {
                        Debug.Log("Button Pressed");
                        RaycastHit hit;
                        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distance))
                        {
                               
                                enemy = hit.transform;
                                Debug.Log(enemy);
                                enemy.SendMessage("hit", SendMessageOptions.DontRequireReceiver);                                              
                        }
                }
                //third raycast that happens every frame
                //tells the hit object to display info, it there is any
                RaycastHit hit3;
                        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit3, distance))
                        {
                               
                                enemy = hit3.transform;
 
                                enemy.SendMessage("info", this, SendMessageOptions.DontRequireReceiver);                                               
                        }
                        //if counter was reset, decrease by one
                        if(textcounter >= 1)
                        {
                                textcounter--;
                        }
        }
        //does damage
        //this now expects an int when its called
        public void Damage(int damageamount)  
        {
        RaycastHit hit2;
                        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit2, distance))
                        {
                               
                                enemy = hit2.transform;
                                Debug.Log(enemy);
                                //it sends a message to the cube
                                enemy.SendMessage("Damage", damageamount, SendMessageOptions.DontRequireReceiver);                                             
                        }
        }
}