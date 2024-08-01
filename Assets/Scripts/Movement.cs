using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] float mainThrust;
    [SerializeField] float mainRotation;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem rightSideParticles;
    [SerializeField] ParticleSystem leftSideParticles;
    [SerializeField] ParticleSystem mainParticles;


    Rigidbody rb;
    AudioSource audioSource;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }


    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);


        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);

        }
        if (!mainParticles.isPlaying)
        {
            mainParticles.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainParticles.Stop();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }

        else if(Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotation();
        }
    }

    void StopRotation()
    {
        leftSideParticles.Stop();
        rightSideParticles.Stop();
    }

     void RotateRight()
    {
        ApplyRotation(-mainRotation);

        if (!leftSideParticles.isPlaying)
        {
            leftSideParticles.Play();
        }
    }

     void RotateLeft()
    {
        ApplyRotation(mainRotation);

        if (!rightSideParticles.isPlaying)
        {
            rightSideParticles.Play();
        }
    }

    public void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
