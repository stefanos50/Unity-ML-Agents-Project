using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using static CarController;

public class MLAgentCar : Agent
{
    private Vector3 originalPosition;

    private EnvironmentParameters behaviorParameters;

    private CarController agent_controller;

    private Rigidbody car_rb;

    [SerializeField]
    private GameObject goal;

    [SerializeField]
    public GameObject[] parked_cars;

    private float last_distance = 100000f;

    private Vector3 start_pos;


    public void change_target()
    {
        transform.position = start_pos;
        transform.localRotation = Quaternion.identity;
        car_rb.velocity = Vector3.zero;
        car_rb.angularVelocity = Vector3.zero;


        GameObject random_car = parked_cars[Random.Range(0, parked_cars.Length)];
        Vector3 goal_position = goal.transform.position;
        Vector3 random_car_position = random_car.transform.position;

        goal.transform.position = random_car_position;
        random_car.transform.position = goal_position;

    }

    public override void Initialize()
    {
        agent_controller = GetComponent<CarController>();
        car_rb = agent_controller.GetComponent<Rigidbody>();
        start_pos = transform.position;
    }

    public override void OnEpisodeBegin()
    {
        change_target();
    }

    void Update()
    {
        if (transform.localPosition.y <= 0)
        {
            RemovePoints();
        }
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(transform.rotation);

        sensor.AddObservation(goal.transform.position);
        sensor.AddObservation(goal.transform.rotation);

        sensor.AddObservation(car_rb.velocity);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Debug.Log(actionBuffers.DiscreteActions[0]);
        int car_action = actionBuffers.DiscreteActions[0];

        if (car_action == 0)
        {

            agent_controller.stop();
        }
        else if (car_action == 1)
        {
            agent_controller.moveBackwards();

        }
        else if (car_action == 2)
        {
            agent_controller.moveForward();

        }
        else if (car_action == 3)
        {
            agent_controller.moveLeft();
        }
        else if (car_action == 4)
        {
            agent_controller.moveRight();
        }
        AddReward(-1f / MaxStep);

        float dist = Vector3.Distance(goal.transform.position, transform.position);

        if (last_distance > dist)
        {
            AddPoints(0.01f);

        }
        else
        {
            AddPoints(-0.01f);
        }
        last_distance = dist;
    }

    public void AddPoints(float amount = 1.0f, bool finished = false)
    {
        AddReward(amount);

        if (finished)
        {

            EndEpisode();
        }
    }

    public void RemovePoints()
    {

        AddReward(-0.01f);

        EndEpisode();
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {

    }
}
