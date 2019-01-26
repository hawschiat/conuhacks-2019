using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public float tilt;
    public GameObject shot;
    public Transform shotSpawn;
    public float nextFire = 0.0f;
    public float fireRate = 0.5f;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveX, 0.0f, moveY);
        rb.velocity = movement*speed;
        Vector3 pos = new Vector3(Mathf.Clamp(rb.position.x,xMin, xMax),0.0f,Mathf.Clamp(rb.position.z,yMin,yMax));
        rb.position = pos;

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x*-tilt);
	}
    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire){
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
       
    }
}
