using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    //public variables
    public GameObject[] barriers;
    public bool[] activation;
    
    //Called when a gameObject is created
    private void Awake()
    {
        for(int i = 0; i < 3; i++)
        {
            activation[i] = RandomBoolean();
        }
        //If boolean array is true, then move barrier upwards
        for(int j = 0;j < 3; j++)
        {
            if (activation[j])
            {
                barriers[j].transform.position = new Vector3(barriers[j].transform.position.x, 0.6f, barriers[j].transform.position.z);
            }
        }
    }
    //Generates a random boolean value in an array
    bool RandomBoolean()
    {
        if(Random.value >= 0.5)
        {
            return true;
        }
        return false;
    }
}
