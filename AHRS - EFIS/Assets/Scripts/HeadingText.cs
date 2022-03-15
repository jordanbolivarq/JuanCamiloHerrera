using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

public class HeadingText : MonoBehaviour
{
    public ScriptB ScriptB;
    public Text Entrada;



    public float heading;

    // Start is called before the first frame update
    void Start()
    {
        Entrada.text = "NaN" + "°"; //datos off;
    }

    // Update is called once per frame
    void Update()
    {

        heading = ScriptB.HEADING_RAW;
        Entrada.text = heading.ToString();
        
    }
    
}
