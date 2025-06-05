using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public GenericPool bulletPool;
    [SerializeField] GameObject explosionPrefab;

    float timer = 40f;
    float speed = 10f;

    Vector3 forward;

    public Transform pointer;
    public float rotationSpeed = 0.5f;

    Rigidbody bulletRb;

    float scoreAddAmount = 4f;

    private void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        pointer = gameObject.transform.GetChild(0);
    }

    private void OnEnable()
    {
        forward = transform.forward;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 40f;
            pointer.GetComponent<BulletPointer>().target = null;
            bulletPool.ReturnToPool(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (pointer.GetComponent<BulletPointer>().target == null)
        {
            bulletRb.linearVelocity = forward * speed;
        }
        else
        {
            bulletRb.linearVelocity = transform.up * -1 * 30;

            transform.rotation = Quaternion.Slerp(transform.rotation, pointer.transform.rotation, rotationSpeed);
            bulletRb.linearVelocity = transform.forward * speed;
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            PowerUpSpawnBehaviour.instance.SelectRandomPowerUp(collision.transform.position);
            GeneralController.instance.CheckEnemies();
            ScoreManagerBehaviour.instance.AddScore(scoreAddAmount);
        }
        
        pointer.GetComponent<BulletPointer>().target = null;
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        bulletPool.ReturnToPool(gameObject);
    }
}
