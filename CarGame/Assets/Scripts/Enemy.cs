using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float shotCounter;

    [SerializeField] float minTimeBetweenShots = 0.2f;

    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject enemyBulletPrefab;

    [SerializeField] float enemyBulletSpeed = 0.3f;

    [SerializeField] float health = 100f;

    [SerializeField] AudioClip enemyDeathSound;

    [SerializeField] [Range(0, 1)] float enemyDeathSoundVolume = 0.75f;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;

    


    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;

        if(shotCounter <= 0f)
        {
            EnemyFire();

            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }

    }

    private void EnemyFire()
    {

        GameObject enemyBullet = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity) as GameObject;

        enemyBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyBulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D bullet)
    {
        DamageDealer DmgDeal = bullet.gameObject.GetComponent<DamageDealer>();

        if (!DmgDeal)
        {
            return;
        }

        ProcessHit(DmgDeal);

    }

    private void ProcessHit(DamageDealer dmgDealer)
    {
        health -= dmgDealer.GetDamage();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);

        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);

        Destroy(explosion, explosionDuration);

        AudioSource.PlayClipAtPoint(enemyDeathSound, Camera.main.transform.position, enemyDeathSoundVolume);

    }

}
