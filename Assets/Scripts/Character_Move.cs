using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour
{
        public float movespeed;
        public float mouseSensitivity = 100.0f;
        public float clampAngle = 80.0f;
        //private float movY = 0;
        

        private float rotY = 0.0f; // rotation around the up/y axis
        private float rotX = 0.0f; // rotation around the right/x axis
        

        void Start()
        {
            movespeed = 10f;
            Vector3 rot = transform.localRotation.eulerAngles;        
            rotY = rot.y;
            rotX = rot.x;
           // Vector3 movY = transform.position.y;
        }
      //  public Vector3 Clamp(ref Vector3 value)
      //{
      //  value.x = Mathf.Clamp(value.x, Min.x, Max.x);
      //  value.y = Mathf.Clamp(value.y, Min.y, Max.y);
      //  value.z = Mathf.Clamp(value.z, Min.z, Max.z);
      //  return value;
      //}

    void Update()
        {
           
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = -Input.GetAxis("Mouse Y");

            rotY += mouseX * mouseSensitivity * Time.deltaTime;
            rotX += mouseY * mouseSensitivity * Time.deltaTime;

            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

            Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
            transform.rotation = localRotation;

           // transform.Translate(movespeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, movespeed * Input.GetAxis("Vertical") * Time.deltaTime);
    }
    }
    

