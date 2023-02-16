using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Egg : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform obj;
    public GameObject full, broken;
    public Rigidbody2D rig;

    void Start()
    {
        obj = GetComponent<Transform>();
        rig = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            
            rig.bodyType = RigidbodyType2D.Static;

            full.SetActive(false);
            Destroy(full);

            broken.SetActive(true);
            this.GetComponent<BoxCollider2D>().isTrigger = true;
            
            Invoke("DestroyEgg", Values.MaxLifeTimeAfterCollision);
        }
    }

    private void DestroyEgg()
    {
        Destroy(this.gameObject);
    }
}
