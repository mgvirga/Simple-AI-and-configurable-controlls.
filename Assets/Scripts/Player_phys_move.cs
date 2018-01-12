using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_phys_move : MonoBehaviour {

    public GameObject[] controllingObject;
    Vector3 movement = new Vector3(27f, 3.5f, 30f);
    bool showGUI = false;
    bool profile1 = true;

    public string menuName;
    string currentProfile = "Profile 1";
    string Controller = "";
    string keyToChange = "null";
    bool getInputKey = false;
    bool keyChanging = false;
    string inputKeyCode_string = " ";
    bool Center = true, MoveLeft = false, MoveRight = false, MoveUp = false, MoveDown = false;
    bool RotateLeft = false, RotateRight = false, RotateUp = false, RotateDown = false;
    
    string UpKeyCode_string = "W", DownKeyCode_string = "S", LeftKeyCode_string = "A", RightKeyCode_string = "D";
    string UpKeyCode_string1 = "W", DownKeyCode_string1 = "S", LeftKeyCode_string1 = "A", RightKeyCode_string1 = "D";
    string UpKeyCode_string2 = "T", DownKeyCode_string2 = "G", LeftKeyCode_string2 = "F", RightKeyCode_string2 = "H";
   
    KeyCode UpKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), "W");
    KeyCode DownKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), "S");
    KeyCode LeftKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), "A");
    KeyCode RightKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), "D");

   
    string KeyDisplay;

    void Start()
    {

    }

    void Update()
    {
       
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey))
            {
                KeyDisplay = vKey.ToString();
               
            }
            else if (Input.GetKeyUp(vKey))
            {
                KeyDisplay = "";
            }
        }

        ChangeKeyCode();

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Alpha1))
        {
            SwitchControlProfile("1");
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Alpha2))
        {
            SwitchControlProfile("2");
        }

        if (!keyChanging)
        {
            if (Input.GetKeyDown(LeftKeyCode))
            {
                MoveLeft = !MoveLeft;
                Center = !Center;
            }
            else if (Input.GetKeyUp(LeftKeyCode))
            {
                MoveLeft = !MoveLeft;
                Center = !Center;
            }

            if (Input.GetKeyDown(RightKeyCode))
            {
                MoveRight = !MoveRight;
                Center = !Center;
            }
            else if (Input.GetKeyUp(RightKeyCode))
            {
                MoveRight = !MoveRight;
                Center = !Center;
            }

            if (Input.GetKeyDown(DownKeyCode))
            {
                MoveDown = !MoveDown;
                Center = !Center;
            }
            else if (Input.GetKeyUp(DownKeyCode))
            {
                MoveDown = !MoveDown;
                Center = !Center;
            }

            if (Input.GetKeyDown(UpKeyCode))
            {
                MoveUp = !MoveUp;
                Center = !Center;
            }
            else if (Input.GetKeyUp(UpKeyCode))
            {
                MoveUp = !MoveUp;
                Center = !Center;
            }
            //wonkie
            if (profile1)
            {
                if (Input.GetAxis("Mouse X") > 0)
                {
                    RotateLeft = true;
                    RotateRight = false;
                }
                else if (Input.GetAxis("Mouse X") < 0)
                {
                    RotateLeft = false;
                    RotateRight = true;
                }
                else
                {
                    RotateLeft = false;
                    RotateRight = false;
                }

                //Mouse input key
                if (Input.GetAxis("Mouse Y") < 0)
                {
                    RotateDown = true;
                    RotateUp = false;
                }
                else if (Input.GetAxis("Mouse Y") > 0)
                {
                    RotateDown = false;
                    RotateUp = true;
                }
                else
                {
                    RotateDown = false;
                    RotateUp = false;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    RotateLeft = true;
                    RotateRight = false;
                }
                else if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    RotateLeft = false;
                    RotateRight = false;
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    RotateLeft = false;
                    RotateRight = true; 
                }
                else if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    RotateLeft = false;
                    RotateRight = false;
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    RotateDown = true;
                    RotateUp = false;
                }
                else if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    RotateDown = false;
                    RotateUp = false;
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    RotateDown = false;
                    RotateUp = true;
                }
                else if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    RotateDown = false;
                    RotateUp = false;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.F1))
        {
            if (showGUI)
            {
                showGUI = false;
                Time.timeScale = 1f;
            }
            else
            {
                showGUI = true;
                Time.timeScale = 0f;
            }
        }
        CubeTranslation();
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
            

    }

    void CubeTranslation()

    {
        if (MoveLeft)
        {
            
            transform.Translate(new Vector3(Vector3.left.x, 0, Vector3.left.z) * (10) * Time.deltaTime);

        }

        if (MoveRight)
        {
            
            transform.Translate(new Vector3(Vector3.right.x, 0, Vector3.right.z) * (10) * Time.deltaTime);

        }

        if (MoveDown)
        {
           
            transform.Translate(new Vector3(Vector3.back.x, 0, Vector3.back.z) *(10) * Time.deltaTime);
        }

        if (MoveUp)
        {
          
            transform.Translate(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * (10) * Time.deltaTime);
        }
        
        if (profile1)
        {
            if (RotateLeft)
            {

                controllingObject[0].transform.Rotate(Vector3.left * 1.2f * Input.GetAxis("Mouse Y"));
                
            }
            if (RotateRight)
            {           
                controllingObject[0].transform.Rotate(Vector3.right * -1.2f * Input.GetAxis("Mouse Y"));
     
            }

            if (RotateUp)
            {
                controllingObject[0].transform.Rotate(Vector3.up * 1.2f * Input.GetAxis("Mouse X"));

            }
            if (RotateDown)
            {

                controllingObject[0].transform.Rotate(Vector3.down * -1.2f * Input.GetAxis("Mouse X"));
            }
        }
        else
        {
            if (RotateLeft)
            {

                controllingObject[0].transform.Rotate(Vector3.up * 1.2f * -5);
               
            }
            if (RotateRight)
            {
               
                controllingObject[0].transform.Rotate(Vector3.down * -1.2f * 5);
              
            }

            if (RotateUp)
            {
                controllingObject[0].transform.Rotate(Vector3.left * 1.2f * -5);

            }
            if (RotateDown)
            {

                controllingObject[0].transform.Rotate(Vector3.right * -1.2f * 5);
            }
        }

       
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);

      
    }

    void SwitchControlProfile(string Scheme)
    {
        switch (Scheme)
        {
            case "1":
                UpKeyCode_string = UpKeyCode_string1;
                DownKeyCode_string = DownKeyCode_string1;
                LeftKeyCode_string = LeftKeyCode_string1;
                RightKeyCode_string = RightKeyCode_string1;
                profile1 = true;
              
                break;
            case "2":
                UpKeyCode_string = UpKeyCode_string2;
                DownKeyCode_string = DownKeyCode_string2;
                LeftKeyCode_string = LeftKeyCode_string2;
                RightKeyCode_string = RightKeyCode_string2;
                profile1 = false;
              
                break;
        }
        Debug.Log(profile1);
        KeyCodeUpdate();
    }

    void KeyCodeUpdate()
    {
        UpKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), UpKeyCode_string);
        DownKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), DownKeyCode_string);
        LeftKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), LeftKeyCode_string);
        RightKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), RightKeyCode_string);

    }
   


    void ChangeKeyCode()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey) && getInputKey)
            {
                inputKeyCode_string = vKey.ToString();
                getInputKey = false;
            }
           
        }
       

        if (keyToChange.Equals("up1"))
        {
            UpKeyCode_string1 = inputKeyCode_string;
        }
        else if (keyToChange.Equals("up2"))
        {
            UpKeyCode_string2 = inputKeyCode_string;
        }
        else if (keyToChange.Equals("down1"))
        {
            DownKeyCode_string1 = inputKeyCode_string;
        }
        else if (keyToChange.Equals("down2"))
        {
            DownKeyCode_string2 = inputKeyCode_string;
        }
        
        if (keyToChange.Equals("right1"))
        {
            LeftKeyCode_string1 = inputKeyCode_string;
        }
        else if (keyToChange.Equals("right2"))
        {
            LeftKeyCode_string2 = inputKeyCode_string;
        }
        else if (keyToChange.Equals("left1"))
        {
            RightKeyCode_string1 = inputKeyCode_string;
        }
        else if (keyToChange.Equals("left2"))
        {
            RightKeyCode_string2 = inputKeyCode_string;
        }

    
    }
   
    
    void OnGUI()
    {
        if (showGUI)

        {
           
            GUI.BeginGroup(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 300, 600, 800));
            GUI.Box(new Rect(0, 100, 600, 400), menuName + " (" + currentProfile + ")");

            if (GUI.Button(new Rect(150, 140, 135, 20), "Profile 1"))
            {
                SwitchControlProfile("1");
                currentProfile = "Profile 1";
            }
            if (GUI.Button(new Rect(325, 140, 135, 20), "Profile 2"))
            {
                SwitchControlProfile("2");
                currentProfile = "Profile 2";
            }


            GUI.Label(new Rect(25, 175, 125, 20), "Keyboard Up ");
            if (GUI.Button(new Rect(150, 175, 135, 20), UpKeyCode_string1))
            {
                keyChanging = true;
                getInputKey = true;
                keyToChange = "up1";
                inputKeyCode_string = " ";
            }

            if (GUI.Button(new Rect(325, 175, 135, 20), UpKeyCode_string2))
            {
                keyChanging = true;
                getInputKey = true;
                keyToChange = "up2";
                inputKeyCode_string = " ";
            }

            GUI.Label(new Rect(25, 200, 125, 20), "Keyboard Down: ");
            if (GUI.Button(new Rect(150, 200, 135, 20), DownKeyCode_string1))
            {
                keyChanging = true;
                getInputKey = true;
                keyToChange = "down1";
                inputKeyCode_string = " ";
            }
            if (GUI.Button(new Rect(325, 200, 135, 20), DownKeyCode_string2))
            {
                keyChanging = true;
                getInputKey = true;
                keyToChange = "down2";
                inputKeyCode_string = " ";
            }
            //bla
            GUI.Label(new Rect(25, 225, 125, 20), "Keyboard left: ");
            if (GUI.Button(new Rect(150, 225, 135, 20), LeftKeyCode_string1))
            {
                keyChanging = true;
                getInputKey = true;
                keyToChange = "left1";
                inputKeyCode_string = " ";
            }

            if (GUI.Button(new Rect(325, 225, 135, 20), LeftKeyCode_string2))
            {
                keyChanging = true;
                getInputKey = true;
                keyToChange = "left2";
                inputKeyCode_string = " ";
            }

            GUI.Label(new Rect(25, 250, 125, 20), "Keyboard right: ");
            if (GUI.Button(new Rect(150, 250, 135, 20), RightKeyCode_string1))
            {
                keyChanging = true;
                getInputKey = true;
                keyToChange = "right1";
                inputKeyCode_string = " ";
            }
            if (GUI.Button(new Rect(325, 250, 135, 20), RightKeyCode_string2))
            {
                keyChanging = true;
                getInputKey = true;
                keyToChange = "right2";
                inputKeyCode_string = " ";
            }
           
            if (GUI.Button(new Rect(220, 300, 135, 20), "Save"))
            {
                if (currentProfile.Equals("Profile 1"))
                {
                    SwitchControlProfile("1");
                }
                else if (currentProfile.Equals("Profile 2"))
                {
                    SwitchControlProfile("2");
                }
                KeyCodeUpdate();
                keyChanging = false;
            }



            GUI.EndGroup();
           
            GUI.Button(new Rect(25, 25, 125, 20), KeyDisplay);
        }
        else
        {
            Time.timeScale = 1f;
        }
        
    }
}
