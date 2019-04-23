using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidBehavior : MonoBehaviour
{
    CarController carController;
    public GameObject canta;
    public int speed;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        carController = GameObject.Find("canta").GetComponent<CarController>();

        if (!carController.getBool()) {
            transform.position += transform.forward * speed * Time.deltaTime;
            transform.LookAt(target);
        }
        if (carController.getBool()) {
            transform.position -= transform.forward * speed * Time.deltaTime;
            transform.LookAt(target);
        }
    
    }
}
