using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPeopleScript : MonoBehaviour
{
    private GameObject cube_status;
    [SerializeField]
    public Material red_mat;
    [SerializeField]
    public Material green_mat;
    // Start is called before the first frame update
    void Start()
    {
        cube_status = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag.ToLower() == "agent")
        {
            StartCoroutine(ChangeColor());

        }
    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.3f);
        cube_status.GetComponent<MeshRenderer>().material = red_mat;
    }


}
