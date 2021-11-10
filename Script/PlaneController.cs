using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaneController : MonoBehaviour
{
    private Vector3 touchPosition, direction;
    private Rigidbody2D rb;
    public float moveSpeed = 1f;
    public float decfuel, decscore;
    public int health, fuel, score;
    public TextMeshProUGUI healthtext, fueltext, scoretext;
    public AudioSource hit;
    public MenuButton menu, multiplier;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthtext.text = health.ToString();
        fueltext.text = fuel.ToString();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

            if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
        }
        if (menu.playing == true)
        {
            decfuel -= Time.deltaTime * menu.multiplier;
            decscore += Time.deltaTime * menu.multiplier;
            fuel = Mathf.RoundToInt(decfuel);
            score = Mathf.RoundToInt(decscore);
            fueltext.text = fuel.ToString();
            scoretext.text = score.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Breakable Objects"))
        {
            health -= 20;
            fuel -= 10;
            healthtext.text = health.ToString();
            fueltext.text = fuel.ToString();
            hit.Play();
        }
        if (collision.CompareTag("Enemy"))
        {
            health -= 40;
            fuel -= 5;
            healthtext.text = health.ToString();
            fueltext.text = fuel.ToString();
            hit.Play();
        }
        if (collision.CompareTag("Projectile"))
        {
            health -= 10;
            fuel -= 15;
            healthtext.text = health.ToString();
            fueltext.text = fuel.ToString();
            hit.Play();
        }
    }
}
