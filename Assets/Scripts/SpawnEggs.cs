using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpawnEggs : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject egg;

    [SerializeField]
    private GameObject eggContainer;
    int maxHen = 5;
    int minHen = -5;

    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 1.5f;
    public float maxLifetime = 5f;

    static public bool stopSpawning = false;
    public TextMeshProUGUI life,score;
    private GameObject[] places;
    private void OnEnable()
    {
        places = new GameObject[maxHen - minHen+1];
        //InvokeRepeating("Spawn", 0f, maxSpawnDelay);
        StartCoroutine(spawnWay());
    }

    private void OnDisable()
    {
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stopSpawning = true;
            stopSpawn();
        }
        if(Input.GetKeyDown(KeyCode.R) && stopSpawning == true)
        {
            stopSpawning = false;
            Values.lives=3;
            life.text = Values.lives.ToString();
            InvokeRepeating("Spawn", 0f, maxSpawnDelay);
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

    IEnumerator spawnWay()
    {
        
        while (!stopSpawning)
        {
            int pos = Random.Range(0, maxHen - minHen + 1);
            print(pos);
            if (places[pos] == null)
            {

                Vector3 position = new Vector3(Values.position[pos], 5, 0);
                GameObject newEgg = Instantiate(egg, position, Quaternion.identity);
                places[pos] = newEgg;

            }
            yield return new WaitForSeconds(3f);
        }
    }
   
    private  void stopSpawn()
    {
        if (stopSpawning == true)
        {
            
            CancelInvoke("Spawn");
            StopAllCoroutines();
        }
    }

    
}
