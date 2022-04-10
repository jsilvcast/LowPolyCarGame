using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform centerOfMass;
    
    //create wheel collider
    public WheelCollider WheelColliderLF;
    public WheelCollider WheelColliderRF;
    public WheelCollider WheelColliderLB;
    public WheelCollider WheelColliderRB;
    
    //create wheel transforms
    public Transform WheelLF;
    public Transform WheelRF;
    public Transform WheelLB;
    public Transform WheelRB;
    
    public float motorTorque = 100f;
    public float maxSteer = 20f;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.localPosition;
    }
    
        
    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        WheelColliderLB.motorTorque = motorTorque * Input.GetAxis("Vertical");
        WheelColliderRB.motorTorque = motorTorque * Input.GetAxis("Vertical");
        WheelColliderLF.steerAngle = maxSteer * Input.GetAxis("Horizontal");
        WheelColliderRF.steerAngle = maxSteer * Input.GetAxis("Horizontal");
        
    }   
    
    // Update is called once per frame
    void Update()
    {
        var pos = Vector3.zero;
        var rot = Quaternion.identity;
        
        WheelColliderLF.GetWorldPose(out pos, out rot);
        WheelLF.transform.position = pos;
        WheelLF.transform.rotation = rot;
        
        WheelColliderRF.GetWorldPose(out pos, out rot);
        WheelRF.transform.position = pos;
        WheelRF.transform.rotation = rot * Quaternion.Euler(0, 180, 0);
        
        WheelColliderLB.GetWorldPose(out pos, out rot);
        WheelLB.transform.position = pos;
        WheelLB.transform.rotation = rot;
        
        WheelColliderRB.GetWorldPose(out pos, out rot);
        WheelRB.transform.position = pos;
        WheelRB.transform.rotation = rot * Quaternion.Euler(0, 180, 0);
        
    }

    
    
}
