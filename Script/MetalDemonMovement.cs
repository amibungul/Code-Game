using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDemonMovement : MonoBehaviour
{
    public float speed;
    public bool neg;
    public int thisMult;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    public AudioSource hit;
    private MenuButton menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MenuButton>();
        thisMult = menu.multiplier;
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Vector3 pos = transform.position;

        if (pos.x < 0)
        {
            neg = true;
        }
        else
        {
            neg = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (Time.timeScale > 0 && menu.playing == true)
        {
            transform.position = pos;
            Movement();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void Movement()
    {
        Vector3 pos = transform.position;
        if (neg == true)
        {
            pos.x += speed + Time.deltaTime;
        }
        else
        {
            pos.x += (speed + Time.deltaTime) * -1;
        }

        transform.position = pos;
    }
}
