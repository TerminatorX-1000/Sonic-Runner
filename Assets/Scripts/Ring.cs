using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public float rotationSpeed = 50;
    public AudioClip ringSound;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed*Time.deltaTime,0,0);
        GetComponent<AudioSource>().clip = ringSound;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            PlayerManager.NumberOfRings++;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject, 1.5f);
        }
    }
}
