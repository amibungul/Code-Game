using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMovement : MonoBehaviour
{
    public float speed;
    private int thisMult;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private MenuButton menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MenuButton>();
        thisMult = menu.multiplier;
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        thisMult = menu.multiplier;
        Vector3 pos = transform.position;
        pos.y -= speed * Time.deltaTime * thisMult;
        transform.position = pos;
        if (transform.position.y < screenBounds.y * -1)
        {
            Destroy(this.gameObject);
        }
    }
}
