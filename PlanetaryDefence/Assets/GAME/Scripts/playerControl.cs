using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public JoyconDemo jcReading;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = jcReading.accel.y * 20f;
        this.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * Time.deltaTime);
        
    }
}
