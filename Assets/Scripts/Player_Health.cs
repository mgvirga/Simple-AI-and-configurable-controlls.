using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour {
    private float start_Health;
    private float current_health;
    public Image HealthBar;
    private float regen;
    private float regenerate = 10f;
    private float lastTime;
  
	// Use this for initialization
	void Start () {
        start_Health = 100;
        current_health = start_Health;
        lastTime = Time.time;
	}
    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            current_health -= 5;
            Debug.Log(current_health);
            HealthBar.fillAmount = current_health / start_Health;
            lastTime = Time.time;
        }
    }
        public void regenerating()
    {
         if ((Time.time > lastTime + regenerate) && (current_health < start_Health))
            {
                current_health += 2;
                Debug.Log(current_health);
                HealthBar.fillAmount = current_health / start_Health;
                lastTime = Time.time;
            }
    }
           
        
       
    

           
	// Update is called once per frame
	void Update ()
    {       
            regenerating();
	}
    
}

 


