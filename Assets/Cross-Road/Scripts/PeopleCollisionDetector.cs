using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleCollisionDetector : MonoBehaviour
{
    private PeopleMLAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<PeopleMLAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag.ToLower() == "wall"||collider.transform.tag.ToLower() == "carai" || collider.transform.tag.ToLower() == "clone")
        {
            agent.RemovePoints();
        }

        if (collider.transform.tag.ToLower() == "goal")
        {
            Debug.Log("Finished");
            agent.AddPoints(5f, true);

        }
    }


    private void OnCollisionEnter(Collision collider)
    {

        if (collider.transform.tag.ToLower() == "wall" || collider.transform.tag.ToLower() == "carai" || collider.transform.tag.ToLower() == "clone")
        {
            agent.RemovePoints(-5f);
        }

        if (collider.transform.tag.ToLower() == "goal")
        {
            Debug.Log("Finished");
            agent.AddPoints(5f, true);

        }
    }
}
