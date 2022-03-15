using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public ScriptB ScriptB;
    public float HEADING_RAW;
    public float hdg_filtered;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        speed = 0.2f;
        HEADING_RAW = ScriptB.HEADING_RAW;
        if (HEADING_RAW >= 10 && HEADING_RAW <= 350){
            hdg_filtered = Mathf.Lerp(hdg_filtered, HEADING_RAW , speed);//FILTRO Daña visualizacion.
            transform.eulerAngles = new Vector3(0, 0, hdg_filtered);
        }else{
            transform.eulerAngles = new Vector3(0, 0, HEADING_RAW);
            hdg_filtered = HEADING_RAW;
        }
        
    }
}
