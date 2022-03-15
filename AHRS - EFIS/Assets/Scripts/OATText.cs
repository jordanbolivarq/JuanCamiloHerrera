using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

public class OATText : MonoBehaviour
{
    public ScriptB ScriptB;
    public Text Entrada;



    public float oat;

    // Start is called before the first frame update
    void Start()
    {
        Entrada.text = "NaN" + "°"; //datos off;
    }

    // Update is called once per frame
    void Update()
    {

        oat = ScriptB.TEMP_OUT_RAW;
        Entrada.text = oat.ToString() + "°C";
        
    }
    
}