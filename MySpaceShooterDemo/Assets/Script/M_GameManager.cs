using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_GameManager : MonoBehaviour
{
    public Transform EnemySpawnPosition;//生成点的基础位置
    private float SpawnDurationTime = 2;//生成的间隔时间
    public GameObject Enemy01;//生成的敌人预制体
    //public GameObject Enemy02;//生成的敌人预制体
    //public GameObject Enemy03;//生成的敌人预制体

    public float startWait;	//开始的暂停时间
    public float spawnWait;	//一批中，单个敌人生成的间隔时间
    public float waveWait; //两批敌人之间的间隔时间
    public int hazardCount;	//一批敌人的数量

    // Start is called before the first frame update
    void Start()
    {
        // 这是另一种生成小行星的办法。
        //StartCoroutine(SpawnWaves());        
    }

    //IEnumerator SpawnWaves()
    //{
    //    yield return new WaitForSeconds(startWait);
    //    while (true)
    //    {
    //        for (int i=0; i<hazardCount; ++i)
    //        {
    //            Vector3 spawnPosition = new Vector3(Random.Range(-EnemySpawnPosition.position.x, EnemySpawnPosition.position.x), EnemySpawnPosition.position.y, EnemySpawnPosition.position.z);
    //            Quaternion spawnQuaternion = Quaternion.identity;
    //            Instantiate(Enemy01, spawnPosition, EnemySpawnPosition.rotation);
    //            yield return new WaitForSeconds(spawnWait);
    //        }
    //        yield return new WaitForSeconds(waveWait);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        CreatEnemy();
    }

    private void CreatEnemy()//生成的方法
    {
        SpawnDurationTime -= Time.deltaTime;
        if (SpawnDurationTime <= 0)
        {
            //Debug.Log(string.Format("EnemySpawnPosition.rotation=" + EnemySpawnPosition.rotation));
            Instantiate(GetRandomEnemy(), new Vector3(GetRandomPos(-4, 4), 0, EnemySpawnPosition.position.z), EnemySpawnPosition.rotation);
            SpawnDurationTime = 2.0f;
        }
    }

    private float GetRandomPos(float Min, float Max)//生成随机数的方法
    {
        return Random.Range(Min, Max);
    }

    private GameObject GetRandomEnemy()
    {
        int r = Random.Range(1, 4);
        GameObject gameObj = null;
        switch (r)
        {
            case 1:
                gameObj = Enemy01;
                break;
            //case 2:
            //    gameObj = Enemy02;
            //    break;
            //case 3:
            //    gameObj = Enemy03;
            //    break;
            default:
                gameObj = Enemy01;
                break;
        }
        return gameObj;
    }
}
