using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType//敌人的类型
{
    Simple,
    Middle,
    Higher,
}

public class Enemy : MonoBehaviour
{

    public EnemyType enemyType;//类型
    public float MoveSpeed;//移动速度
    public GameObject ExplosionVFX;//陨石爆炸粒子
    private AudioSource ExplosionAS;

    // Start is called before the first frame update
    void Start()
    {
        ExplosionAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        DealWithEnemyType();

        // 销毁超出屏幕的陨石
        if (transform.position.z < -20)
        {
            Destroy(gameObject);
        }
    }

    public void DealWithEnemyType()//处理敌人类型的各种操作，敌人类型不同，攻击运动方式也不一样
    {
        switch (enemyType)
        {
            case EnemyType.Simple:
                SimpleEnemyMoveMent();
                break;
            case EnemyType.Middle:
                break;
            case EnemyType.Higher:
                break;
            default:
                break;
        }
    }

    private void SimpleEnemyMoveMent()
    {
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")//与子弹进行碰撞
        {
            Debug.Log("is playing " + ExplosionAS.isPlaying);
            if (!ExplosionAS.isPlaying)
            {
                ExplosionAS.Play();
            }

            Destroy(other.gameObject);//销毁子弹

            GameObject ex = Instantiate(ExplosionVFX, transform.position, Quaternion.identity);//生成爆炸粒子
            Destroy(gameObject, 0.15f);//销毁本体
            Destroy(ex, 0.15f);//销毁爆炸粒子
        }
    }
}
