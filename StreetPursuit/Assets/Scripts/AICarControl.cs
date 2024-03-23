using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AICarcontrol : MonoBehaviour
{
    public float motorTorque = 2000;
    public float brakeTorque = 2000;
    public float maxSpeed = 20;
    public float steeringRange = 30;
    public float steeringRangeAtMaxSpeed = 10;
    public float centreOfGravityOffset = -1f;
    public Transform target;

    WheelControl[] wheels;
    Rigidbody rigidBody;
    NavMeshAgent agent;
    public float stopDuration = 3f;
    Boolean isStopped = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();

        // Adjust center of mass vertically, to help prevent the car from rolling
        rigidBody.centerOfMass += Vector3.up * centreOfGravityOffset;

        // Find all child GameObjects that have the WheelControl script attached
        wheels = GetComponentsInChildren<WheelControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStopped)
            return;

        //float vInput = Input.GetAxis("Vertical");
        //float hInput = Input.GetAxis("Horizontal");
        if (agent == null || !agent.isActiveAndEnabled || !agent.isOnNavMesh)
            return;
        agent.SetDestination(target.position);

        // Calculate current speed in relation to the forward direction of the car
        // (this returns a negative number when traveling backwards)
        float forwardSpeed = Vector3.Dot(transform.forward, rigidBody.velocity);


        // Calculate how close the car is to top speed
        // as a number from zero to one
        float speedFactor = Mathf.InverseLerp(0, maxSpeed, forwardSpeed);

        // Use that to calculate how much torque is available 
        // (zero torque at top speed)
        float currentMotorTorque = Mathf.Lerp(motorTorque, 0, speedFactor);

        // …and to calculate how much to steer 
        // (the car steers more gently at top speed)
        float currentSteerRange = Mathf.Lerp(steeringRange, steeringRangeAtMaxSpeed, speedFactor);

        // Calculate desired velocity from the agent
        Vector3 desiredVelocity = agent.desiredVelocity.normalized * maxSpeed;

        // Calculate the steering angle
        float hInput = Vector3.SignedAngle(transform.forward, desiredVelocity, Vector3.up) / currentSteerRange;


        // Check whether the user input is in the same direction 
        // as the car's velocity
        //bool isAccelerating = Mathf.Sign(vInput) == Mathf.Sign(forwardSpeed);
        bool isAccelerating = forwardSpeed > 0;

        foreach (var wheel in wheels)
        {
            // Apply steering to Wheel colliders that have "Steerable" enabled
            if (wheel.steerable)
            {
                wheel.WheelCollider.steerAngle = hInput * currentSteerRange;
            }

            if (isAccelerating)
            {
                // Apply torque to Wheel colliders that have "Motorized" enabled
                if (wheel.motorized)
                {
                    //wheel.WheelCollider.motorTorque = vInput * currentMotorTorque;
                    wheel.WheelCollider.motorTorque = currentMotorTorque;

                }
                wheel.WheelCollider.brakeTorque = 0;
            }
            else
            {
                // If the user is trying to go in the opposite direction
                // apply brakes to all wheels
                //wheel.WheelCollider.brakeTorque = Mathf.Abs(vInput) * brakeTorque;
                //wheel.WheelCollider.motorTorque = 0;
                wheel.WheelCollider.brakeTorque = brakeTorque;
                wheel.WheelCollider.motorTorque = 0;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == target.transform)
        {
            rigidBody.isKinematic = true;
            StopCarForDuration(stopDuration);
        }
    }

    void StopCarForDuration(float duration)
    {
        isStopped = true;

        foreach (var wheel in wheels)
        {
            wheel.WheelCollider.brakeTorque = brakeTorque;
            wheel.WheelCollider.motorTorque = 0;
        }

        StartCoroutine(ResumeAfterDuration(duration));
    }

    // Coroutine to resume car movement after a delay
    IEnumerator ResumeAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);

        isStopped = false;
        rigidBody.isKinematic = false;

        foreach (var wheel in wheels)
        {
            wheel.WheelCollider.brakeTorque = 0;
        }
    }
}

