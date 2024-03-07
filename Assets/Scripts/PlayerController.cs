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
    Rigidbody physic;
    AudioSource audioPlayer;
    [SerializeField] int Speed;
    [SerializeField] int Tilt;
    [SerializeField] float NextFire;
    [SerializeField] float FireRate;
    public Boundary boundary;

    public GameObject Shot;
    public GameObject ShotSpawn;

    void Start()
    {
        physic = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
    }
     void Update()
    {
       
        if (Input.GetButton("Fire1") && Time.time>NextFire)
        {
            NextFire = Time.time+FireRate;
            Instantiate(Shot, ShotSpawn.transform.position, ShotSpawn.transform.rotation);
            audioPlayer.Play();
        }
        
    } 
    void FixedUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(MoveHorizontal, 0, MoveVertical);

        physic.velocity = movement*Speed;

        Vector3 position = new Vector3(
            Mathf.Clamp(physic.position.x,boundary.xMin,boundary.xMax),
            0,
            Mathf.Clamp(physic.position.z,boundary.zMin,boundary.zMax)
            );

        physic.position = position;


        physic.rotation = Quaternion.Euler(0,0,physic.velocity.x*Tilt);
    }
}
