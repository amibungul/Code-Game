using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCrystalMovement : MonoBehaviour
{
    private Vector2 screenBounds;
    public MenuButton menu;
    public float speed, dir;
    private bool desc;
    public AudioSource fire;

    // Start is called before the first frame update
    void Start()
    {
        desc = true;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        menu = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MenuButton>();

        Vector3 pos = transform.position;
        if (pos.y < 0)
        {
            desc = false;
            transform.Rotate(0.0f, 0.0f, 180.0f);
            dir *= -1;
        }
        speed *= menu.multiplier;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (desc == true)
        {
            pos.y -= speed * Time.deltaTime;
        }
        else
        {
            pos.y += speed * Time.deltaTime;
        }
        transform.position = pos;

        if (pos.y < screenBounds.y * -1 || pos.y > screenBounds.y)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Breakable Objects"))
        {
            Destroy(this.gameObject);
        }
    }
}
