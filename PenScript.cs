using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;

public class PenScript : MonoBehaviour
{
    public float minreachx;
    public float minreachy;
    public float minreachz;
    public GameObject pp;
    void Start()
    {
        pp = GameObject.FindWithTag("PenObject");
        minreachx= (float)(pp.transform.localPosition.x-0.02);
      
        minreachy = (float)(pp.transform.localPosition.y - 0.02);
        
        minreachz = (float)(pp.transform.localPosition.z - 0.02);
        Alk(minreachx, minreachy, minreachz);


    }



    void Alk(float input1, float input2, float input3)
    {
        using (FileStream fs = new FileStream(@"\Users\Tanisha\Desktop\MinReachPen.csv", FileMode.Append, FileAccess.Write))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {

                sw.WriteLine("Theminimum reach position for the pen is:");
                sw.Write(input1 + " , " + input2 + " , " + input3);
                sw.Write("\r\n");

                sw.Close();
            }
        }

    }
}
