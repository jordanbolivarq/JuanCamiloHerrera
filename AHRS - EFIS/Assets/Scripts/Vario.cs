using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vario : MonoBehaviour
{
    public ScriptB ScriptB;
    public float VS_RAW;
    public float set;
    public float off;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        set = 0.054f;
        VS_RAW = ScriptB.VS_RAW;

        if ((VS_RAW >= -1000 && VS_RAW <= 1000)){
            transform.position = new Vector3( transform.position.x, 1043 + VS_RAW*0.079f, transform.position.z);
        }
        if (VS_RAW > 1000){
            transform.position = new Vector3( transform.position.x, 1068 + VS_RAW*set, transform.position.z);
        }
        if (VS_RAW < -1000){
            transform.position = new Vector3( transform.position.x, 1019 + VS_RAW*set, transform.position.z);
        }


    }
}
