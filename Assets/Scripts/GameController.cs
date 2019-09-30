using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public Transform spawnObj = null;
    public Transform spawnPoint = null;
    public float startTimeInternal = 1.0f;
    public float spawnTimeInternal = 1.0f;
    

    public Transform[] barrages;
    public Transform barrageSpawnPoint = null;
    public Vector2 barrageBoundargy;
    public float barrageStartTimeInternal = 1.0f;
    public float barrageSpawnTimeInternal = 1.0f;
    public float barrageWaveTimeInternal = 1.0f;
    public float barrageCountPerWave = 10;

    public float restartDelayTime = 1.0f;

    private static GameController gameController = null;
    private bool gameOver = false;
    private bool restart = false;

    static public GameController Get()
    {
        if(gameController == null)
        {
            GameObject obj = GameObject.FindWithTag("GameController");
            gameController = obj.GetComponent<GameController>();
            
            if(gameController == null)
            {
                gameController = obj.AddComponent<GameController>();
            }
            //DontDestroyOnLoad(obj);
        }
        return gameController;
    }

    private void Start()
    {
        StartCoroutine(SpawnPlatform());
        // 弹幕
        StartBarrage();
    }

    private void Update()
    {
        if (restart)
        {
            Invoke("Restart", restartDelayTime);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator SpawnPlatform()
    {
        yield return new WaitForSeconds(startTimeInternal);
        while (true)
        {
            if (gameOver || spawnObj == null || spawnPoint == null)
            {
                break;
            }
            Instantiate(spawnObj, spawnPoint);
            yield return new WaitForSeconds(spawnTimeInternal);
        }
    }

    public void StartBarrage()
    {
        StartCoroutine(SpawnBarrage());
    }

    IEnumerator SpawnBarrage()
    {
        yield return new WaitForSeconds(barrageStartTimeInternal);
        while (true)
        {
            if (gameOver || barrages == null || barrages.Length <= 0 || barrageSpawnPoint == null)
            {
                break;
            }

            for (int i = 0; i < barrageCountPerWave; ++i)
            {
                Transform barrageSpawnObj = barrages[Random.Range(0, barrages.Length)];
                if(barrageSpawnObj == null)
                {
                    continue;
                }
                Transform barrage = Instantiate(barrageSpawnObj, barrageSpawnPoint);
                Vector3 position = barrage.position;
                position.y += Random.Range(barrageBoundargy.x, barrageBoundargy.y);
                barrage.position = position;
                yield return new WaitForSeconds(barrageSpawnTimeInternal);
            }
            yield return new WaitForSeconds(barrageWaveTimeInternal);
        }
    }

    public void GameOver()
    {
        gameOver = true;
        restart = true;
    }
}
