using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    public GameObject[] ast;
    GameObject asteroid;
    public Vector2 screenBounds;

    //time to spawn
    [Space(3)]
    public float waitForSpawn;
    public float countdown;

    //scale
    [Header("Scale of asteroid")]
    public float minScale;
    public float maxScale;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        asteroid = ast[Random.Range(0, ast.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            SpawnAsteroid();
            countdown = waitForSpawn;
            asteroid = ast[Random.Range(0, ast.Length)];
        }
    }
    
    void SpawnAsteroid()
    {
        float scale = Random.Range(minScale, maxScale);
        GameObject s = Instantiate(asteroid);
        s.transform.position = new Vector3(Random.Range(screenBounds.x * -1, screenBounds.x), screenBounds.y, 2);
        s.transform.localScale = new Vector3(scale, scale, 1);
    }
}
