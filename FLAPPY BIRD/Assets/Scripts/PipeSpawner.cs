using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    //starting timer at 0
    public float time = 0f;
    //rate of pipe spawn
    public float timer = 1.5f;
    //place to spawn
    public Transform spawnPoint;
    // range of spawn
    public float height = 10f;
    //time to destroy pipe after
    public float timeToDeath = 15f;
    public bool gameStarted = false;
    private void Start()
    {
        spawnPoint = GetComponent<Transform>();
        gameStarted = false;
    }

    private void Update()
    {
        if (gameStarted)
        {
            //spaw pipe every time
            if (time >= timer)
            {
                SpawnPipe();

                time = 0f;
            }
            //working timer
            time += Time.deltaTime;
        }
    }

    public void SpawnPipe()
    {
        //spawn pipe
        GameObject newPipe = (GameObject)Instantiate(pipePrefab, new Vector3(transform.position.x, Yspawn(), 0), Quaternion.identity);
        //destroy pipe afer x seconds
        Destroy(newPipe, timeToDeath);
    }
    // generating Y position
    private float Yspawn()
    {
        float y = Random.Range(0, height);
        return y;
    }
}