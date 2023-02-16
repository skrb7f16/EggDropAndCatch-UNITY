using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Base : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI life;
    public TextMeshProUGUI instruction;

    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _hatchSound;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            instruction.text = "";
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Egg"))
        {
            print("collision from base");
            collision.gameObject.tag = "HatchedEgg";
            _audioSource.clip = _hatchSound;
            _audioSource.Play();
            if (Values.lives > 0)
            {

                Values.lives--;
                life.text = Values.lives.ToString();
            }
            else
            {
                SpawnEggs.stopSpawning = true;
                instruction.text = "game over press R to play again";
            }
        }
    }
}
