using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRigidbody;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();


    }

    private void Start()
    {
        float speed = 50f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.GetComponent<BulletTarget>() != null)
        //{
        //    // Hit target

        //}
        //else
        //{
        //    // Hit something else
        //}
        Destroy(gameObject);
    }


}
