using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    public  Transform transformComponent;
    public bool toStop=false;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _bounceSound;
    [SerializeField]
    private AudioClip _pointGain;

    public int speedx = 3;

    public TextMeshProUGUI score;
    void Start()
    {
        
        transformComponent = GetComponent<Transform>();
        _audioSource= GetComponent<AudioSource>();
        _audioSource.clip = _bounceSound;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (toStop == true) return;

        if (Input.GetKeyDown(KeyCode.UpArrow)) increseSpeed();
        if (Input.GetKeyDown(KeyCode.DownArrow)) decreaseSpeed();

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {


            GetComponent<Rigidbody2D>().velocity = new Vector2(speedx, 0);
            
        }
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {


            GetComponent<Rigidbody2D>().velocity = new Vector2(-speedx, 0);
        }
    }

    private void FixedUpdate()
    {
        if (transformComponent.position.x >= 17f)
        {
          
            _audioSource.Play();
            toStop = true;
            stopbasket(17f,-0.4f);

            return;
        }
        if (transformComponent.position.x <= -17f)
        {
            _audioSource.Play();
            toStop = true;
            stopbasket(-17f,0.4f);
            return;
        }
    }

    void stopbasket(float pos,float factor)
    {
        
        transformComponent.position=new Vector3(pos+factor, transformComponent.position.y, transformComponent.position.z);
        GetComponent<Rigidbody2D>().AddForce(Vector2.zero, ForceMode2D.Force);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        toStop = false;
    }

    void increseSpeed()
    {
        if(speedx<10)
        speedx++;
    }

    void decreaseSpeed()
    {
        if(speedx>1)
        speedx--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            _audioSource.clip = _pointGain;
            _audioSource.Play();
            Destroy(collision.gameObject);
            int sc = int.Parse(score.text);
            sc++;
            score.text = sc.ToString();
        }
    }
}
