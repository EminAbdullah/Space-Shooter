using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    AudioSource audioSource;

    Rigidbody physic;

    public float speed,tilt;
    public Boundary boundary;
    [SerializeField]
    private float fireRate;
    private float nextFire;

    [SerializeField]
    private GameObject laser, shotSpawn;


    private void Start()
    {
        physic = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire) 
        {
            nextFire = Time.time+fireRate;
            Instantiate(laser, shotSpawn.transform.position, shotSpawn.transform.rotation);
            audioSource.Play();
        }
       
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        physic.velocity = movement*speed;

        Vector3 position = new Vector3(
            Mathf.Clamp(physic.position.x, boundary.xMin, boundary.xMax),
            0,
            Mathf.Clamp(physic.position.z, boundary.zMin, boundary.zMax)
            );
        physic.position = position;

        physic.rotation = Quaternion.Euler(0, 0, physic.velocity.x * tilt);
    }
}
