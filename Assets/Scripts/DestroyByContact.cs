using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject PlayerExplosion;

    private GameController gameController;


    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "Boundary")
        {
            return;
        }

        Instantiate(Explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
            gameController.gameOver();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);

        gameController.UpdateScore();
    }
}
