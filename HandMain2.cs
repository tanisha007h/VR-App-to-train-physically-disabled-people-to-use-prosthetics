using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;

public class HandMain2 : MonoBehaviour
{
    public GameObject RightHand2;
    public Vector3 Restp2;
    public Quaternion Restrot2;
    public Vector3[] restposition2 = new Vector3[100];
    public Quaternion[] restrotation2 = new Quaternion[100];

    // Use this for initialization
    void Start()
    {
        Restp2 = RightHand2.transform.localPosition;
        
        Restrot2 = RightHand2.transform.localRotation;
        restposition2[1] = Restp2;
        print(restposition2[1]);
        restrotation2[1] = Restrot2;
        print(restrotation2[1]);
        if ((transform.localPosition == restposition2[1]) && (transform.localRotation == restrotation2[1]))
            System.Threading.Thread.Sleep(5000);
        Alk(Restp2);
        Alp(Restrot2);
    }

    void Alk(Vector3 input)
    {
        using (FileStream fs = new FileStream(@"\Users\Tanisha\Desktop\Rest2Right.csv", FileMode.Append, FileAccess.Write))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("Resting Position 2:");

                sw.Write(input);

                sw.WriteLine("\r\n");
                sw.Close();
            }
        }

    }
    void Alp(Quaternion inp)
    {
        using (FileStream fs = new FileStream(@"\Users\Tanisha\Desktop\Rest2Right.csv", FileMode.Append, FileAccess.Write))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("Resting Rotation 2:");

                sw.Write(inp);

                sw.WriteLine("\r\n");
                sw.Close();
            }
        }

    }
}

