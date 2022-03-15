using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

public class VSText : MonoBehaviour
{
    public ScriptB ScriptB;
    public Text Entrada;



    public float vs;

    // Start is called before the first frame update
    void Start()
    {
        Entrada.text = "NaN" + "°"; //datos off;
    }

    // Update is called once per frame
    void Update()
    {

        vs = ScriptB.VS_RAW;
        Entrada.text = "VS: " + vs.ToString() + " ft/m";
        
    }
    
}