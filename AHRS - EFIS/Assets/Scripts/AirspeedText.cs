using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

public class AirspeedText : MonoBehaviour
{
    public ScriptB ScriptB;
    public Text Airspeed;
    public Text Altitude;



    public float airspeed;
    public float altitude;

    // Start is called before the first frame update
    void Start()
    {
        //Entrada.text = "NaN" + "°"; //datos off;
    }

    // Update is called once per frame
    void Update()
    {

        airspeed = ScriptB.AIRSPEED_RAW;
        altitude = ScriptB.ALTITUDE_RAW;

        Airspeed.text = airspeed.ToString();
        Altitude.text = altitude.ToString();

        
    }
    
}