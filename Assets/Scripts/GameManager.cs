using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] platformsObj;

    [SerializeField]
    int objCount;

    [SerializeField]
    Transform objPool;

    
    float objDistance;

    float distance,xPos = 10f;

    [SerializeField]
    GameObject fuelObj;

    [SerializeField]
    int fuelCount;

    private void Start()
    {
        randomObjSpawner();
        randomFuelObjSpawner();
    }

    public void randomObjSpawner()
    {
        int i = 0;
        while( i < objCount)
        {
            int randomObj = Random.Range(0,7);
            objDistance = Random.Range(30, 50);
            Instantiate(platformsObj[randomObj], new Vector3(distance,0,0), transform.rotation,objPool);
            distance += objDistance;
            i++;
        }
    }

    private void randomFuelObjSpawner()
    {
        int i = 0;
        while(i < fuelCount)
        {
            int randomX = Random.Range(60, 90);
            int randomY = Random.Range(-25, 25);
            xPos += randomX;           
            Instantiate(fuelObj, new Vector3(xPos, randomY, 0), transform.rotation);          
            i++;
        }
    }
}
