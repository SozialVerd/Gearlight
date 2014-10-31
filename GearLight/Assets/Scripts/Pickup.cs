using UnityEngine;
using System.Collections;
 
public class Pickup : MonoBehaviour
{
public GameObject player;
        public health inventory;
        public string infotext = "agility + 1";
        void Awake ()
        {
                player = GameObject.FindWithTag("Player");
                inventory = player.GetComponent<health>();
        }
       
        void hit()
        {
                inventory.agility++;
                Destroy(gameObject);
        }
       
        void info(caster a)
        {
                //set the infotext and reset the counter
                a.information = infotext;
                a.textcounter = a.textmax;
        }
}