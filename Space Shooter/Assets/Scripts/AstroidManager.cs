using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AstroidManager : MonoBehaviour
{
    public GameObject explosion,playerExplosion;
    Rigidbody physic;
    public int speed;
    public int score;

    GameController gameController;
    private void Awake()
    {
        //gameController=GameObject.FindWithTag("GameController").GetComponent<GameController>();
        gameController = GameObject.FindObjectOfType<GameController>();
    }

    void Start()
    {
        physic = GetComponent<Rigidbody>();

        physic.angularVelocity = Random.insideUnitSphere * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="laser")
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            gameController.Score();
            Destroy(other.gameObject);
        }
        if (other.tag=="Player")
        {
            Destroy(other.gameObject);
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
    }

}
