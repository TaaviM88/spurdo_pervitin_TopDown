using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public float spawnRate = 0.5f;
    public float nextSpawn = 0f;
    public int howManyEnemySpaws = 10;
    //public float speed = 3f;
    public float rangeWhenPlayerIsClose = 25;
    public float howManySecondToWaitBeforeActiveAgain = 10f;
    public GameObject sensor;
    //public Transform pointA;
    //public Transform pointB;
    int enemySpawnCount;
    int currentEnemyIndex = 0;
    int currentWave = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawnCount = howManyEnemySpaws;
        if(enemySpawnCount == -1)
        {
            currentEnemyIndex = -2;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //float time = Mathf.PingPong(Time.time * speed, 1);
        //transform.position = Vector2.Lerp(pointA.position, pointB.position, time);
        if(Vector3.Distance(sensor.transform.position, PlayerManager.Instance.GetPlayerPosition()) < rangeWhenPlayerIsClose)
        {
            if (Time.time > nextSpawn && currentEnemyIndex < enemySpawnCount)
            {
                nextSpawn = Time.time + spawnRate;
                GameObject newEnemy = Instantiate(enemyPrefabs[currentWave], transform.position, Quaternion.identity) as GameObject;
                //-1 = infinite
                if (enemySpawnCount != -1)
                {
                    currentEnemyIndex++;
                    if(currentEnemyIndex >= enemySpawnCount)
                    {
                        StartCoroutine(Cooldown());
                    }
                }

                //laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            }
        }

    /*    if (currentEnemyIndex >= enemySpawnCount)
        {
            currentWave++;
            if (currentWave > enemyPrefabs.Count - 1)
            {

                currentWave = 0;

            }

            currentEnemyIndex = 0;
        }
        */
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(sensor.transform.position, rangeWhenPlayerIsClose);
        //Gizmos.DrawWireSphere(attackPosDown.position, attackDownRange);
    }


    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(howManySecondToWaitBeforeActiveAgain);
        currentEnemyIndex = 0;
    }
}
