using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {
    public GameObject Gun;
    public float speed = 50;
    public float firerate = 0.5f;
    public GameObject BulletSpawn;
    public Rigidbody Projectile;
    public Rigidbody Projectile1;
    private float nextshot;
    private int i;



   


    public void Update()
    {
        
       
            i = Random.Range(1, 101);
        
        if (Input.GetKey(KeyCode.Mouse0) && (Time.time > nextshot) && (i > 50) && (Time.timeScale == 1f))

                {
                    
                    delay();
                    shootn();
                }
         
                if (Input.GetKey(KeyCode.Mouse0) && (Time.time > nextshot) && (i <= 50) && (Time.timeScale == 1f))
                {
                    
                    delay();
                    shootn1();
                }
    }

    public void delay()
    {
        nextshot = Time.time + firerate;
        
    }
    


    //if (Input.GetKey(KeyCode.Mouse0))
    //{
    //    if (currenttimer <= 2*k+1)
    //    {
    //        shootn1();
    //        currenttimer = timer;
    //    }
    //    currenttimer--;
    //}







    public void shootn()
    {

        Rigidbody instProjectile = Instantiate(Projectile, BulletSpawn.transform.position, BulletSpawn.transform.rotation) as Rigidbody;
        instProjectile.velocity = BulletSpawn.transform.TransformDirection(new Vector3(-speed, 0, 0));
        
    }
    public void shootn1()
    {

        Rigidbody instProjectile1 = Instantiate(Projectile1, BulletSpawn.transform.position, BulletSpawn.transform.rotation) as Rigidbody;
        instProjectile1.velocity = BulletSpawn.transform.TransformDirection(new Vector3(-speed, 0, 0));
       
    }
}
