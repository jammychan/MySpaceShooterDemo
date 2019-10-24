using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletMoveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        Debug.Log("bullet layer = " + gameObject.layer);
        gameObject.layer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
    }

    private void BulletMove()//移动的方法
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        transform.Translate(0, 0, BulletMoveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DestroyBounder")
        {
            Destroy(gameObject);
        }
    }
}
