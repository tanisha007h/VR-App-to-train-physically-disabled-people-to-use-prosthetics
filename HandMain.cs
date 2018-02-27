using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;

public class HandMain : MonoBehaviour
{
    public GameObject RightHand;
    public Vector3 restp1;
    public Quaternion restrot1;
    public Vector3[] restposition1 = new Vector3[100];
    public Quaternion[] restrotation1 = new Quaternion[100];
    public float yRotation = 5.0f;


    // Use this for initialization
    void Start()


    {
      
        restp1 = RightHand.transform.localPosition;
        restrot1 = RightHand.transform.localRotation;
        restposition1[1] = restp1;
        //print(restposition1[1]);
        restrotation1[1] = restrot1;
        //print(restrotation1[1]);
        if((transform.localPosition==restposition1[1])&&(transform.localRotation==restrotation1[1]))
            System.Threading.Thread.Sleep(5000);
        

        Alk(restp1);
        Alp(restrot1);
    }



    void Alk(Vector3 input)
    {
        using (FileStream fs = new FileStream(@"\Users\Tanisha\Desktop\Rest1Right.csv", FileMode.Append, FileAccess.Write))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("Resting Position 1:");
               
                sw.Write(input);

                sw.WriteLine("\r\n");
                sw.Close();
            }
        }

    }
    void Alp(Quaternion inp)
    {
        using (FileStream fs = new FileStream(@"\Users\Tanisha\Desktop\Rest1Right.csv", FileMode.Append, FileAccess.Write))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("Resting Rotation 1:");

                sw.Write(inp);

                sw.WriteLine("\r\n");
                sw.Close();
            }
        }

    }
    
    
       

       
        // Move joints
        void FixedUpdate()
        {

            float horz = Input.GetAxis("Horizontal"); //takes in values from left and right keys; note that sensitivity was set to 3 to mimic joystick values
            //float vert = Input.GetAxis("Vertical"); //takes in values from up and down keys
            float allow = Input.GetAxis("Cancel"); //using this as a conditional statement (i.e. during reach, allow arm to rotate). its connected to the escape button
        

            if (Mathf.Abs(horz) < .4) //value has to be greater than .4 or less than -.4 to be accepted
                horz = 0;
            print(horz);
            if (allow > 0) //this is tied to the escape button
            {
                yRotation=yRotation + horz;
                RightHand.transform.eulerAngles = new Vector3(0,0,yRotation * 0.1f);
            //print("Hi");
            }

            //to move the arm, press down on the escape button, while pressing up and down arrows. 
        }
    


   
}
