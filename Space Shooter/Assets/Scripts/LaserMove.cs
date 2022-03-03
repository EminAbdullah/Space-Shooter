using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    Rigidbody physic;
    [SerializeField]
    private float speed;
    void Start()
    {
        physic = GetComponent<Rigidbody>();
        physic.velocity = transform.forward*speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
