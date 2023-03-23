using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCollisionDetector : MonoBehaviour
{
    private MLAgentCar agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<MLAgentCar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag.ToLower() == "wall" || collider.transform.tag.ToLower() == "fence" || collider.transform.tag.ToLower() == "car")
        {
            agent.RemovePoints();
        }
    }


    private void OnCollisionEnter(Collision collider)
    {
        if (collider.transform.tag.ToLower() == "wall" || collider.transform.tag.ToLower() == "fence" || collider.transform.tag.ToLower() == "car")
        {
            agent.RemovePoints();
        }
    }
}
