using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShip : MonoBehaviour
{

    public Transform Motor;
    public float SteerPower = 500f;
    public float Power = 5f;
    public float MaxSpeed = 10f;
    public float Drag = 0.1f;


    protected Rigidbody Rigidbody;
    protected Quaternion StartRotaion;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        StartRotaion = Motor.localRotation;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        var forceDirection = transform.forward;
        var steer = 0;

        if (Input.GetKey(KeyCode.A))
        {
            steer = 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            steer = -1;
        }


        Rigidbody.AddForceAtPosition(steer * transform.right * SteerPower / 100f, Motor.position);


    }
}
