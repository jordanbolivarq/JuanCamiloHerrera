using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

public class RAW : MonoBehaviour
{
    public ScriptB ScriptB;
    public float acc_x;
    public float acc_y;
    public float acc_z;
    public float total_g;
    public float pitch;
    public float roll;
    public float heading;
    public Text Entrada;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {

        acc_x = ScriptB.ACC_X;
        acc_y = ScriptB.ACC_Y;
        acc_z = ScriptB.ACC_Z;
        pitch = ScriptB.PITCH_RAW;
        roll = ScriptB.ROLL_RAW;
        heading = ScriptB.HEADING_RAW;
        total_g = ScriptB.TOTAL_G; 
        Entrada.text = acc_x.ToString() + "\n" + acc_y.ToString() + "\n" + acc_z.ToString() + "\n" +
                        total_g.ToString() + "\n" +
                        pitch.ToString() + "\n" + roll.ToString() + "\n" + heading.ToString() + "\n";




    }
}
