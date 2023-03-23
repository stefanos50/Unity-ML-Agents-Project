using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] car_spawners;
    [SerializeField]
    public GameObject[] cars;
    [SerializeField]
    public GameObject env;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawn", 0f, Random.Range(1.2f, 2f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawn()
    {
        GameObject random_spawner = car_spawners[Random.Range(0, car_spawners.Length)];
        foreach (GameObject spawn_obj in car_spawners)
        {
            if(random_spawner.GetInstanceID() == spawn_obj.GetInstanceID())
            {
                continue;
            }
            if (Random.Range(0, 2) == 1)
            {
                GameObject newAI = Instantiate(cars[Random.Range(0, cars.Length)], spawn_obj.transform.position, Quaternion.identity);
                newAI.tag = "clone";
                newAI.transform.SetParent(env.transform);
            }
        }
    }
}
