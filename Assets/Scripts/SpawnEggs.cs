using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEggs : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject egg;

    int maxHen = 5;
    int minHen = -5;

    public float minSpawnDelay = 3f;
    public float maxSpawnDelay = 10f;
    public float maxLifetime = 5f;

    static public bool stopSpawning = false;

    private GameObject[] places;
    private void OnEnable()
    {
 
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    void Start()
    {
        places = new GameObject[maxHen - minHen];
        InvokeRepeating("Spawn", 0f, maxSpawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stopSpawning = true;
            stopSpawn();
        }

    }



    private void Spawn()
    {
        if (stopSpawning == true)
        {
            stopSpawn();
            return;
        }
        int pos = Random.Range(0, maxHen - minHen + 1);
        print(pos);
        if (places[pos] == null)
        {
            
            Vector3 position = new Vector3(Values.position[pos] , 5, 0);
            GameObject newEgg = Instantiate(egg, position, Quaternion.identity);
            places[pos] = newEgg;
            
        }
    }

   
    private  void stopSpawn()
    {
        if (stopSpawning == true)
        {
            CancelInvoke("Spawn");
        }
    }

    
}
