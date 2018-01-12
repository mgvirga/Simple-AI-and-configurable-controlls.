using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public Image Enemyhealth;
    public float start_health;
    public float ehealth;
    public GameObject Enemy;
    //Transform target;
   
    // Use this for initialization
    void Start () {
        //target = transform.parent;
        start_health = 100;
        ehealth = start_health;
    }
    public void OnTriggerEnter(Collider bullet)
    {
        if (bullet.tag == "Bullet")
        {
            ehealth -= 20;
            Debug.Log(ehealth);
            Enemyhealth.fillAmount = ehealth / start_health;
        }
        if (bullet.tag == "Bullet1")
        {
            ehealth -= 10;
            Debug.Log(ehealth);
            Enemyhealth.fillAmount = ehealth / start_health;
        }
      
}

    // Update is called once per frame
    void Update () {
        if (ehealth <= 0)
        {
            Destroy(this.Enemy);
        }
       // Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);

    }
}
