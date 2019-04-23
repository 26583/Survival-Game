using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public int speed;
    private int r;
    private bool pickUp = false;
    public Camera fpsCam;
    private float range = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            Shoot();
        }

        transform.position += transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A)) {
            r -= 1;
        }
        if (Input.GetKey(KeyCode.D)) {
            r += 1;
        }
        transform.rotation = Quaternion.Euler(0, r, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "car") {
            Application.LoadLevel("GameOver");
        }
        if (other.gameObject.name == "arena") {
            Application.LoadLevel("GameOver");
        }
        if (other.gameObject.name == "pickUp") {
           // Application.LoadLevel("GameOver");
            Destroy(other.gameObject);
            pickUp = true;
        }
    }
    public bool getBool()
    {
        return pickUp;
    }
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            if(hit.transform.name == "car") {
                Destroy(hit.transform.gameObject);
            }
            Debug.Log(hit.transform.name);
        }
    }
}
