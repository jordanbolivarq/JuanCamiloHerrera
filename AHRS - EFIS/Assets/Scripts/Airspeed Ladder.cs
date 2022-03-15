using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airspeed : MonoBehaviour
{
    public ScriptB ScriptB;
    public float AIRSPEED_RAW;
    public float airspeed_filtered;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        speed = 0.2f;
        AIRSPEED_RAW = ScriptB.AIRSPEED_RAW;
        airspeed_filtered = Mathf.Lerp(airspeed_filtered, AIRSPEED_RAW , speed);
        transform.position = new Vector3( transform.position.x, 1000 + airspeed_filtered*10 , transform.position.z);
    }
}
