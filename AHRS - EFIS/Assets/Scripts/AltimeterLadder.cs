using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltimeterLadder : MonoBehaviour
{
    public ScriptB ScriptB;
    public float ALTITUDE_RAW;
    public float altitude_filtered;
    public float speed;
    public float multiplier = 0.396f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        speed = 0.05f;
        ALTITUDE_RAW = ScriptB.ALTITUDE_RAW;
        altitude_filtered = Mathf.Lerp(altitude_filtered, ALTITUDE_RAW , speed);
        transform.position = new Vector3( transform.position.x, 5005 - altitude_filtered*multiplier , transform.position.z);
    }
}
