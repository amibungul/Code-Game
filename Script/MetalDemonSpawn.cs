using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDemonSpawn : MonoBehaviour
{
    public GameObject[] en;
    GameObject enemy;
    public Vector2 screenBounds;
    public MenuButton menu;
    public float speed, dir;

    //time to spawn
    [Space(3)]
    public float waitForSpawn;
    public float countdown;
    public float frequency;

    //scale
    [Header("Scale of enemy")]
    public float minScale;
    public float maxScale;


    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        enemy = en[Random.Range(0, en.Length)];
        InvokeRepeating("SpawnEnemy", 5, frequency);
        InvokeRepeating("GetFaster", 20, 20);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float y = Mathf.PingPong(Time.time * speed, 2) * 5 - 5;
        transform.position = new Vector3(pos.x, y * dir, 2);
    }

    private void SpawnEnemy()
    {
        if (menu.playing == true)
        {
            Vector3 pos = transform.position;
            float scale = Random.Range(minScale, maxScale);
            GameObject s = Instantiate(enemy) as GameObject;
            s.transform.localScale = new Vector3(scale, scale, 1);

            s.transform.position = pos;
        }
    }
    void GetFaster()
    {
        frequency -= 0.5f;
    }

}

