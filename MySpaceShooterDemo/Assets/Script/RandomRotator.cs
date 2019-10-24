using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector3(
            rb.angularVelocity.x + Random.insideUnitSphere.x * tumble,
            rb.angularVelocity.y,
            rb.angularVelocity.z + Random.insideUnitSphere.z * tumble);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
