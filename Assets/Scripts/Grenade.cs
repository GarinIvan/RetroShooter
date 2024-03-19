using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float damage;
    public float delay;
    public GameObject explosionPrefab;
    public Transform explosionParticle;
    private void Start()
    {
        Destroy(gameObject, 10);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", delay);
    }
    private void Explosion()
    {
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
        var explosionPart = Instantiate(explosionParticle);
        explosionPart.transform.position = transform.position;
        explosion.GetComponent<Explosion>().damage = damage;
        Destroy(gameObject);
    }
}
