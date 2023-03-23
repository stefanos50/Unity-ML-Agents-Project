using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerAI : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    [SerializeField] float steer = 20f;
    private Rigidbody agentRigidBody;

    [SerializeField] private GameObject fr_wheel;
    [SerializeField] private GameObject fl_wheel;
    [SerializeField] private GameObject br_wheel;
    [SerializeField] private GameObject bl_wheel;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.4f, 0.9f);
        agentRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
   
        fr_wheel.transform.Rotate(3000 / 60 * 360 * Time.deltaTime, 0, 0);
        fl_wheel.transform.Rotate(3000 / 60 * 360 * Time.deltaTime, 0, 0);
        br_wheel.transform.Rotate(3000 / 60 * 360 * Time.deltaTime, 0, 0);
        bl_wheel.transform.Rotate(3000 / 60 * 360 * Time.deltaTime, 0, 0);
    }

    void FixedUpdate()
    {
        moveForward();
    }

    public void moveForward()
    {
        agentRigidBody.AddForce(transform.forward * speed, ForceMode.VelocityChange);
        fl_wheel.transform.rotation = Quaternion.Euler(fl_wheel.transform.rotation.eulerAngles.x, 0, fl_wheel.transform.rotation.eulerAngles.z);
        fr_wheel.transform.rotation = Quaternion.Euler(fl_wheel.transform.rotation.eulerAngles.x, 0, fl_wheel.transform.rotation.eulerAngles.z);
    }

    public void moveLeft()
    {
        agentRigidBody.AddTorque(transform.up * -steer);
        fl_wheel.transform.rotation = Quaternion.Euler(fl_wheel.transform.rotation.eulerAngles.x, -30, fl_wheel.transform.rotation.eulerAngles.z);
        fr_wheel.transform.rotation = Quaternion.Euler(fl_wheel.transform.rotation.eulerAngles.x, -30, fl_wheel.transform.rotation.eulerAngles.z);
    }

    public void moveRight()
    {
        agentRigidBody.AddTorque(transform.up * steer);
        fl_wheel.transform.rotation = Quaternion.Euler(fl_wheel.transform.rotation.eulerAngles.x, 30, fl_wheel.transform.rotation.eulerAngles.z);
        fr_wheel.transform.rotation = Quaternion.Euler(fl_wheel.transform.rotation.eulerAngles.x, 30, fl_wheel.transform.rotation.eulerAngles.z);
    }

    public void moveBackwards()
    {
        agentRigidBody.AddForce(transform.forward * -speed, ForceMode.VelocityChange);
        fl_wheel.transform.rotation = Quaternion.Euler(fl_wheel.transform.rotation.eulerAngles.x, 0, fl_wheel.transform.rotation.eulerAngles.z);
        fr_wheel.transform.rotation = Quaternion.Euler(fl_wheel.transform.rotation.eulerAngles.x, 0, fl_wheel.transform.rotation.eulerAngles.z);
    }

    public void stop()
    {
        agentRigidBody.velocity = new Vector3(0, 0, 0);
        fl_wheel.transform.rotation = Quaternion.Euler(fl_wheel.transform.rotation.eulerAngles.x, 0, fl_wheel.transform.rotation.eulerAngles.z);
        fr_wheel.transform.rotation = Quaternion.Euler(fl_wheel.transform.rotation.eulerAngles.x, 0, fl_wheel.transform.rotation.eulerAngles.z);
    }
}

