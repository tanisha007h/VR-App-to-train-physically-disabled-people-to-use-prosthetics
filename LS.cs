using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;

public class LS : MonoBehaviour
{
    public GameObject Righty;
     public Text ReachText;
    public GameObject Ball;
    public GameObject Pen;
    public GameObject Bottle;
    public GameObject Drawer;
    public GameObject Key;
    public GameObject Cube;
    public GameObject pPlane3;
    public GameObject[] allobjects = new GameObject[6];
    private Vector3[] positions = new Vector3[6];


    //float movement;
    // public float yRotation = 5.0f;
    public float xposition;
    public float yposition;
    public float zposition;
    public float part;
    public int var=0;
    private int i=0;
    //For disabling objects only once

    // Use this for initialization
    void Start()
    {
        
        Righty = GameObject.FindWithTag("Player");

        xposition = Righty.transform.localPosition.x;
        yposition = Righty.transform.localPosition.y;
        zposition = Righty.transform.localPosition.z;
        part = 1;
  
        positions[0] = new Vector3(0, 0.62f, 0);
        positions[1] = new Vector3(0, 0.532f, 0);
        positions[2] = new Vector3(0, 0.595f, 0);
        positions[3] = new Vector3(0, 0.661f, 0);
        positions[4] = new Vector3(0, 0.552f, 0);

    }





    // Move joints
    void Update()
    {
        //1)position object and reinitialize arm 
      if (Mathf.Approximately(part, 1.0f))
      {
                Ball = GameObject.FindGameObjectWithTag("Ball");
                Pen = GameObject.FindGameObjectWithTag("PenObject");
                Drawer = GameObject.FindGameObjectWithTag("Drawer");
                Bottle = GameObject.FindGameObjectWithTag("Bottle");
                Key = GameObject.FindGameObjectWithTag("Key");
                Cube = GameObject.FindGameObjectWithTag("Key");
                pPlane3 = GameObject.FindGameObjectWithTag("Key");


            allobjects[0] = Ball.gameObject;
                allobjects[1] = Pen.gameObject;
                allobjects[2] = Drawer.gameObject;
                allobjects[3] = Bottle.gameObject;
                allobjects[4] = Key.gameObject;
      }

        
         foreach (GameObject ity in allobjects)
         {
                 if (i > 0)
               { allobjects[i - 1].gameObject.GetComponent<MeshRenderer>().enabled = false; }


                if (Input.GetButton("Jump") == true)
                {
                    var = var + 1;
                }

                if (var == 1)
                {
                    if (allobjects[i] != null)
                    {
                        EnableComp();
                    }
                    part = part + 1.0f;
                }


                if (Input.GetButton("Jump") == true)
                    var = var + 1;


                //insert pause
                //2)display reach
                if (var == 2)
                {
                    if (Mathf.Approximately(part, 2.0f))

                    {
                        SetText();
                        part = part + 1.0f;
                    }
                }
                if (Input.GetButton("Jump") == true)
                    var = var + 1;


                if (var > 2)
                //3)Reach
                //get joystick data and zero it if necessary
                {
                    if (Mathf.Approximately(part, 3.0f))

                    {
                        float horz = Input.GetAxis("Horizontal"); //takes in values from left and right keys; note that sensitivity was set to 3 to mimic joystick values
                        float vert = Input.GetAxis("Vertical"); //takes in values from up and down keys
                        float zert = Input.GetAxis("Fire2");
                        // float allow = Input.GetAxis("Cancel"); //using this as a conditional statement (i.e. during reach, allow arm to rotate). its connected to the escape button
                        if (Mathf.Abs(horz) < .4) //value has to be greater than .4 or less than -.4 to be accepted
                            horz = 0;
                        if (Mathf.Abs(vert) < .4) //value has to be greater than .4 or less than -.4 to be accepted
                            vert = 0;
                        if (Mathf.Abs(zert) < .4) //value has to be greater than .4 or less than -.4 to be accepted
                            zert = 0;
                        //get current shoulder position
                        xposition = Righty.transform.position.x;
                        yposition = Righty.transform.position.y;
                        zposition = Righty.transform.position.z;
                        //calculate new position 
                        float newxposition = xposition + vert;
                        float newyposition = yposition + zert;
                        float newzposition = zposition + horz;
                        // print(vert);
                        Vector3 all = new Vector3(newxposition * 1.0f, newyposition * 1.0f, newzposition * 1.0f);
                        print(all);
                        Righty.transform.position = all;


                    if (Input.GetButton("Fire3") == true)
                    {

                        var = 0;
                        part = 2;
                        i += 1;
                    }
                    else
                        break;

                    }
                





                    //to move the arm, press down on the escape button, while pressing up and down arrows. 
                }
            print(i);
           
            
         }
        
    
        
    }
    void SetText()
    {
        if (ReachText == null)
        { ReachText = GetComponent<Text>(); }

        else
        {
            ReachText.text = "Ready? Press Space!";
        }
    }
     void EnableComp()
    {
        if (allobjects[i]!= null)
        {
            allobjects[i].gameObject.GetComponent<MeshRenderer>().enabled = true;
            allobjects[i].gameObject.transform.localPosition = positions[i];
        }
    }
  
}
