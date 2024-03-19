using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenageCaster : MonoBehaviour
{
    public float damage;
    public Rigidbody grenadePrefab;
    public Transform granadeSourceTransform;
    public float force = 10;
    public float startTime = 1;
    private float _shootTime;
    private void Start()
    {
        _shootTime = 0;
    }
    void Update()
    {
        _shootTime -= Time.deltaTime;
        if (Input.GetMouseButton(1) && _shootTime <= 0)
        {
            _shootTime = startTime;
            var grenade = Instantiate(grenadePrefab);
            grenade.transform.position = granadeSourceTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(granadeSourceTransform.forward * force * 0.5f);
            grenade.GetComponent<Rigidbody>().AddForce(granadeSourceTransform.up * force);
            grenade.GetComponent<Grenade>().damage = damage;
        }
        if (_shootTime <= 0) _shootTime = 0;
    }
}
