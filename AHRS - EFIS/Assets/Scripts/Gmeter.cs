using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gmeter : MonoBehaviour
{
    public ScriptB ScriptB;
    public float VERT_ACC_RAW;
    public float az_filtered;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        speed = 0.2f;
        VERT_ACC_RAW = ScriptB.VERT_ACC_RAW;
        az_filtered = Mathf.Lerp(az_filtered, VERT_ACC_RAW , speed);//FILTRO Daña visualizacion.
        transform.eulerAngles = new Vector3(0, 0, -az_filtered * 43.5f);//NEGATIVO PORQUE ASI FUNCIONA UNITY   
    }
}
