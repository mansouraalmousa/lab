using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHouse : MonoBehaviour
{

    private float rotationSmoothness = 1f;
    [SerializeField]
    private float rotationAcceleration = 0.1f;
    [SerializeField]
    private float rotationInterval = 20f;
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private float timer = 0f;
    private AudioSource SoundAudio;
    public AudioClip audioClip;

    private void Start()
    {
        SoundAudio = GetComponent<AudioSource>();
        //initialRotation = transform.rotation;
    }

    private void GenerateRandomRotation()
    {
        // Select a random rotation axis (0 for X, 1 for Y, 2 for Z)
        int randomAxis = Random.Range(0, 3);

        // Select a random rotation angle between 0 and 360 degrees
        float randomAngle = Random.Range(1,2)*90f;

        // Set the target rotation Euler angles based on the random axis and angle
        Vector3 rotationAxis = Vector3.zero;
        rotationAxis[randomAxis] = 1f; // 1f represents the axis to rotate around (X, Y, or Z)

        // Rotate the room around the random axis by the random angle
        targetRotation = Quaternion.AngleAxis(randomAngle, rotationAxis) * initialRotation;
    }

    private void Update()
    {
        initialRotation = transform.rotation;
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer >= rotationInterval)
        {
            SoundAudio.PlayOneShot(audioClip);
            // Wait for the sound to finish playing before initiating the rotation
            Invoke("GenerateRandomRotation", audioClip.length);
            timer = 0f;
        }
        // Rotate the room gradually and realistically towards the new angle using Slerp
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothness * Time.deltaTime);
        // Apply acceleration to make the rotation feel more realistic

        float rotationSpeed = Quaternion.Angle(transform.rotation, targetRotation) * rotationAcceleration *Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}






