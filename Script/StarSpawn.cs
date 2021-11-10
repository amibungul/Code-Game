using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawn : MonoBehaviour
{
    public GameObject star;
    private Vector2 screenBounds;

    //time to spawn
    [Space(3)]
    public float waitForSpawn = 5;
    public float countdown = 5;

    //scale of star
    public float minScale;
    public float maxScale;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            SpawnStar();
            countdown = waitForSpawn;
        }
    }

    void SpawnStar()
    {
        float scale = Random.Range(minScale, maxScale);
        GameObject s = Instantiate(star);
        s.transform.position = new Vector3(Random.Range(screenBounds.x * - 1, screenBounds.x), screenBounds.y, 1);
        s.transform.localScale = new Vector3(scale, scale, 1);
    }
}
