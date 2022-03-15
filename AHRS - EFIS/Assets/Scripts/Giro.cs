using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        new WaitForSeconds(5);
        
    }


    public ScriptB ScriptB;
    public static int NeverSleep;//
    public float input;
    public float speed;
    public float gx;
    public float gy;
    public float gz;
    public float roll;
    public float roll_filtered;
    public float pitch;
    public float pitch_filtered;
    public float x_offset;
    public float y_offset;
    public bool flag;
    public float ax;
    public float width;
    public float height;
    public float res_factor_x;
    public float res_factor_y;
    float pos_x;
    float pos_y;
    float pitch_linear;

    // Update is called once per frame
    void Update()
    {
        //Resolution[] resolutions = Screen.resolutions;
        width = Screen.width;
        height = Screen.height;

        if (height == 1080){ //Resolucion iPhone 8 plus
            pos_x = 600;
            pos_y = 682;
            pitch_linear = 8.65f;
        }

        if (height == 1536){ //Resolucion iPad mini 2
            pos_x = 493;
            pos_y = 1045;
            pitch_linear = 12.4f;
        }


    
    speed = 0.2f;
    Vector3 acc = Input.acceleration;
    ax = acc.x;

    if (ax == 0){
        flag = true;
        gy = 1;
    }else{
        flag = false;
    }

    gx = acc.x;
    gy = acc.y;
    gz = acc.z;


    pitch = ScriptB.PITCH_RAW;
    roll = ScriptB.ROLL_RAW;
    //roll = (Mathf.Atan(-gx/gy) * 57.2958f);
    //pitch = (Mathf.Atan(-gz/gy) * 57.2958f);
    //pitch = 0;
    //roll = 0;

    //degrees = roll;

    

    //roll_filtered = Mathf.Lerp(roll_filtered, roll , speed); //Le entra un valor y saca otro suavizado.
    //pitch_filtered = Mathf.Lerp(pitch_filtered, pitch , speed); //Le entra un valor y saca otro suavizado.
    
    if (flag == false){ //La bandera chequea que el vector del acelerometro de prueba no este vacio.
    //Esto significa que el codigo solo empieza cuando todos los perifericos del iPad esten disponibles.

        //roll_filtered = roll;
        roll_filtered = Mathf.Lerp(roll_filtered, roll , speed);


        //pitch_filtered = pitch;
        pitch_filtered = Mathf.Lerp(pitch_filtered, pitch , speed);

        x_offset = pitch_filtered * 14.5f * Mathf.Sin(roll/57.2958f);//
        y_offset = 0;

        transform.eulerAngles = new Vector3(0, 0, roll_filtered); //lleva el angulo z al valor calculado.
        transform.position = new Vector3( ( pos_x + x_offset ) , ( pos_y - pitch_filtered*pitch_linear* Mathf.Cos(roll_filtered/57.2958f)), transform.position.z);

    }else{
        x_offset = pitch * 14.5f * Mathf.Sin(roll/57.2958f);//
        transform.eulerAngles = new Vector3(0, 0, roll); //lleva el angulo z al valor offline
        transform.position = new Vector3( ( pos_x + x_offset ) , ( pos_y - pitch*pitch_linear* Mathf.Cos(roll/57.2958f)), transform.position.z);
    }
    
    
    
    //if( Mathf.Abs(degrees-input) < 0.05){ //Cuando la diferencia es menor a 0.05 grados se igualan ambos valores para evitar muchos decimales.
    //   degrees = input;
    //}


    //Vector3 to = new Vector3(0, 0, degrees);
    //transform.rotation = Vector3.Slerp(transform.rotation.eulerAngles, to, speed * Time.deltaTime);


    //Vector3 to = new Vector3(0, 0, degrees);
    //transform.eulerAngles = Vector3.Slerp(transform.rotation.eulerAngles, to, Time.deltaTime);

    }
    

}
