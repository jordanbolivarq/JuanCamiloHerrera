using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

public class CabinTemp : MonoBehaviour
{
    public ScriptB ScriptB;
    public Text Entrada;



    public float cabin_temp;

    // Start is called before the first frame update
    void Start()
    {
        Entrada.text = "NaN" + "°"; //datos off;
    }

    // Update is called once per frame
    void Update()
    {

        cabin_temp = ScriptB.TEMP_IN_RAW;
        Entrada.text = cabin_temp.ToString()+"°C";
        
    }
    
}