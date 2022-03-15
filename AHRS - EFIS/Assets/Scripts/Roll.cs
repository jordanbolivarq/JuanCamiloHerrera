using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public Giro scriptA;
    public float roll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        roll = scriptA.roll_filtered;
        transform.eulerAngles = new Vector3(0, 0, roll);
    }
}
