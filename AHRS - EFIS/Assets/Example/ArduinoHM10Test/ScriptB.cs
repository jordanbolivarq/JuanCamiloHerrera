using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

public class ScriptB : MonoBehaviour
{
    public ArduinoHM10Test ArduinoHM10Test;
    public Giro Giro;
    public Text Entrada;
    public string input;
    public string datos;
    public string datos_pruebas;
    public float[] data_input;
    public bool flag;
    public float ax;

    public float PITCH_RAW;
    public float ROLL_RAW;
    public float HEADING_RAW;
    public float ALTITUDE_RAW;
    public float VS_RAW;
    public float TEMP_IN_RAW;
    public float TEMP_OUT_RAW;
    public float AIRSPEED_RAW;
    public float QNH;
    public float AOA_RAW;
    public float SS_RAW;
    public float VERT_ACC_RAW;
    public float LAT_ACC_RAW;
    public float ACC_X;
    public float ACC_Y;
    public float ACC_Z;
    public float TOTAL_G;

    public int header;

    // Start is called before the first frame update
    void Start()
    {
        datos_pruebas = "9,0.01,0.02,1,1,000";
        //datos = "2,0,0,1013";
    }

    // Update is called once per frame
    void Update()
    {

        input = ArduinoHM10Test.INPUT;
        Entrada.text = input.ToString();

        Vector3 acc = Input.acceleration;
        ax = acc.x;

        
        if (ax == 0){
            datos = input;//es que el sensor iPad no es detectado.
        }else{
            
            datos = input;//hace la accion con sensor iPad detectado.
        }

        
        
        //data_input = Array.ConvertAll(datos.Split(','), float.Parse);
        data_input = Array.ConvertAll(datos_pruebas.Split(','), float.Parse);

        header = Convert.ToInt32(data_input[0]);

        switch (header){
            case 1:
            PITCH_RAW = data_input[1];
            ROLL_RAW = data_input[2];
            HEADING_RAW = data_input[3];
            break;
            case 2:
            ALTITUDE_RAW = data_input[1];
            VS_RAW = data_input[2];
            QNH = data_input[3];
            break;
            case 3:
            TEMP_IN_RAW = data_input[1];
            TEMP_OUT_RAW = data_input[2];
            AIRSPEED_RAW = data_input[3];
            break;
            case 7:
            AOA_RAW = data_input[1];
            SS_RAW = data_input[2];
            VERT_ACC_RAW = data_input[3];
            LAT_ACC_RAW = data_input[4];
            break;
            case 9:
            ACC_Y = data_input[1];
            ACC_X = data_input[2];
            ACC_Z = data_input[3];
            break; 
            case 10:
            TOTAL_G = data_input[1];
            break;




        }

        /*
        PITCH_RAW = data_input[0];
        ROLL_RAW = data_input[1];
        HEADING_RAW = data_input[2];
        ALTITUDE_RAW = data_input[3];
        VS_RAW = data_input[4];
        TEMP_IN_RAW = data_input[5];
        TEMP_OUT_RAW = data_input[6];
        AIRSPEED_RAW = data_input[7];
        */


    }
}
