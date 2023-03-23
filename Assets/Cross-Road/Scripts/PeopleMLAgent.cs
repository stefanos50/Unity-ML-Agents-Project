using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using static CarController;

public class PeopleMLAgent : Agent
{
    private Vector3 originalPosition;

    //private BehaviorParameters behaviorParameters;
    private EnvironmentParameters behaviorParameters;

    private Rigidbody pl_rb;
    private float dist;
    [SerializeField]
    private GameObject goal;

    private float last_distance = 100000f;

    private Vector3 start_pos;


    public void reset()
    {
        pl_rb.velocity = Vector3.zero;
        pl_rb.angularVelocity = Vector3.zero;


        transform.localPosition = new Vector3(-19f, -21.84f, Random.Range(-35, 40));
        transform.localRotation = Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f);
        last_distance = 100000f;

    }

    public override void Initialize()
    {
        pl_rb = this.GetComponent<Rigidbody>();
        start_pos = transform.position;
    }

    public override void OnEpisodeBegin()
    {
        reset();
    }

    void Update()
    {

    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(transform.localRotation);
        sensor.AddObservation(dist);
    }
    float turnSpeed = 3f, moveSpeed = 8f;
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        int people_action_1 = actionBuffers.DiscreteActions[0];
        int people_action_2 = actionBuffers.DiscreteActions[1];
        //Debug.Log(people_action);
        if (people_action_1 == 0)
        {
            pl_rb.velocity = Vector3.zero;
            pl_rb.angularVelocity = Vector3.zero;
        }
        else if (people_action_1 == 1)
        {        
            transform.Translate(-Vector3.forward * (moveSpeed / 2f) * Time.fixedDeltaTime);

        }
        else if (people_action_1 == 2)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.fixedDeltaTime);

        }

        if (people_action_2 == 0)
        {
            transform.Rotate(new Vector3(0f, -1f, 0f) * turnSpeed);
        }
        else if (people_action_2 == 1)
        {
            transform.Rotate(new Vector3(0f, 1f, 0f) * turnSpeed);
        }
        AddReward(-1f / MaxStep);

        dist = 80f - transform.localPosition.x;

        if (dist < last_distance)
        {
            AddReward(0.1f);
            last_distance = dist;

        }
        else
        {
            AddReward(-0.1f);
        }
    }

    public void AddPoints(float amount = 1.0f, bool finished = false)
    {
        AddReward(amount);

        if (finished)
        {
            EndEpisode();
        }
    }

    public void RemovePoints(float amount=-0.01f)
    {

        AddReward(amount);
        EndEpisode();
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {

    }
}
