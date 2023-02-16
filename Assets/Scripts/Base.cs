using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Base : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI life;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Egg"))
        {
            print("collision from base");
            collision.gameObject.tag = "HatchedEgg";

            if (Values.lives > 0)
            {

                Values.lives--;
                life.text = Values.lives.ToString();
            }
            else
            {
                SpawnEggs.stopSpawning = true;
                life.text = "game over";
            }
        }
    }
}
