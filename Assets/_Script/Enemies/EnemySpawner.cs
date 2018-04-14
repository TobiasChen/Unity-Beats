using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Camera Camera;
    public List<Vector3> Spawnposition;
    
    public int MaxWaveSize = 5;
    public int SpawnCount;
    public float TimeBetweenWaves = 5f;
    public List<GameObject> Enemy;
    public AnimationCurve curve;
    
    
    private void Start()
    {
        //Finds Camera
        Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //Calculates the Distance from the middle to a corner
        float radius = Mathf.Sqrt(Mathf.Pow(Camera.orthographicSize, 2f) +Mathf.Pow(Camera.orthographicSize * Camera.main.aspect, 2f));
        
        //Breaks the Spawnprocess, if the User specified a Spawncount smaller one
        if (SpawnCount < 1)
        {
            print("There can't be less then one Spawner, no Spawnpoints created");
            this.enabled = false;
        }
        
        else
        {
            for (var i = 1; i <= SpawnCount; i++)
            {
                //Calculates the Angle that represents the current percentage of the circle
                float PercentageAngle = ((float)i / (float)SpawnCount) * 360f - (1f / SpawnCount * 360f);
                //Converts the Angle to Radiants
                float PercentageRadiant = Mathf.Deg2Rad * PercentageAngle;
                //Finds the position of the Current percentage on the circle with the above defined radius and add it to the List of Spawnpositions
                var x = Mathf.Cos(PercentageRadiant) * radius;
                var y = Mathf.Sin(PercentageRadiant) * radius;
               Spawnposition.Add(new Vector3(x, y, 0));
            }
            //Starts the Spawning of new Ships
            StartCoroutine(WaveTimer());
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator WaveTimer()
    {
        //Keeps Running while the Script is active
        while (true)
        {
            //Spawn a new Wave, then wait for 5 Seconds
            StartCoroutine(WaveCounter());
            yield return new WaitForSeconds(TimeBetweenWaves);
        }
    }
    IEnumerator WaveCounter()
    {
        //Get a random position and Shipcount for the wave
        var position = Spawnposition[Random.Range(0, Spawnposition.Count)];
        var wavesize = Mathf.Round(MaxWaveSize * curve.Evaluate((Random.value)));
        print("Ship Count: " + wavesize);

        //Calls to spawn a number of new ships equal to the defined Wavesize
        for (var i = 1; i <= wavesize; i++)
            yield return StartCoroutine(Wavespawn(position));
    }
    IEnumerator Wavespawn(Vector2 position)
    {
        //Finnally Spawns a new Enemy, then waits 0.5 Seconds until the next one is spawned, to keep Spacing between them.
        Instantiate(Enemy[0], new Vector3(position.x, position.y, 0f), transform.rotation);
        yield return new WaitForSeconds(0.5f);
    }

}