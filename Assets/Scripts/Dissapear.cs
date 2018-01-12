using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissapear : MonoBehaviour
{
    public GameObject Bullet;
    public float timer;
    
    // Use this for initialization
    void Start()
    {
        timer = 50;
    }

    // Update is called once per frame
    void Update()
    {
        timer--;
       if (timer <= 0)
        {
            Destroy(this.Bullet);
        }
        
        
           
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(this.Bullet);
                   
        }
        if(other.tag == "Wall")
        {
            DestroyObject(this.Bullet);
          
        }
        if(other.tag == "Ground")
        {
            DestroyObject(this.Bullet);
           
        }
    }
    
}
