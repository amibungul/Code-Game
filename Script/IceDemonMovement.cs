using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDemonMovement : MonoBehaviour
{
    private Vector2 screenBounds;
    public MenuButton menu;
    public float speed, dir, fireRate;
    bool exit;
    public GameObject iceCrystal;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        menu = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MenuButton>();
        exit = false;
        Vector3 pos = transform.position;
        if (pos.y < 0)
        {
            transform.Rotate(0.0f, 0.0f, 180.0f);
            dir *= -1;
        }
        speed *= menu.multiplier;

        fireRate = Random.Range(0.1f, 1);

        Invoke("ExitStage", 10);

        InvokeRepeating("ShootBullet", fireRate, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (exit == false)
        {
            float x = Mathf.PingPong(Time.time * speed, 2) * 3 - 3;
            transform.position = new Vector3(x, pos.y, 2);
        }
        if (exit == true)
        {
            if (pos.x < screenBounds.x * -1 || pos.x > screenBounds.x)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void ShootBullet()
    {

        Vector3 pos = transform.position;
        GameObject i = Instantiate(iceCrystal);
        if (pos.y >= 0)
        {
            i.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.5f, this.transform.position.z);
        }
        if (pos.y < 0)
        {
            i.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

    void ExitStage()
    {
        Vector3 pos = transform.position;
        if (pos.x < 0)
        {
            pos.x -= speed * Time.deltaTime;
            exit = true;
        }
        if (pos.x > 0 || pos.x == 0)
        {
            pos.x += speed * Time.deltaTime;
            exit = true;
        }
        transform.position = pos;
    }
}
