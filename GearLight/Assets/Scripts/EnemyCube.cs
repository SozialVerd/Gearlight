using UnityEngine;
using System.Collections;
 
public class EnemyCube : MonoBehaviour
{
        public Transform target;
        public int Health = 10;
        public float speed;
        public float attack;
        public health script1;
        public int countdown;
        public int maxcount;
        //the text that is displayed on mouseover
        public string infotext = "slimey cube";
		public int givexp;
		
		
 
        //arguments  \/
        void Damage(int damageamount)
        {
                audio.Play();
				particleSystem.Play();
 
                Debug.Log ("i was hit");
                Health -= damageamount;
                if (Health <= 0)
                {
						script1.gainexp(givexp);
                        Destroy (gameObject);
                }      
        }
        //function that gets called on mouseover
        void info(caster a)
        {
                //set the infotext and reset the counter
                a.information = Health.ToString();
                a.textcounter = a.textmax;
        }
 
       
 
        // Use this for initialization
        void Start ()
        {
			
                target = GameObject.FindWithTag("Player").transform;
                script1 = target.GetComponent <health> ();
 
        }
       
        // Update is called once per frame
        void Update ()
        {       
			transform.LookAt(target);
			transform.rotation = new Quaternion(0,transform.rotation.y,0,transform.rotation.w);
			float dist = Vector3.Distance(transform.position, target.position);
				if (dist >= attack-.1)
					{
					transform.Translate(Vector3.forward * Time.deltaTime *speed);
					}
             
                if (countdown == 0)
                {
                        if (dist <= attack)
                        {
                                script1.script1health = script1.script1health-10;
                        }
                        countdown=maxcount;
                }
                else
                {
                        countdown=countdown-1;
                }
               
        }
 
}