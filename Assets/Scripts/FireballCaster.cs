﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public float damage = 10;
    public Fireball fireballPrefab;
    public Transform fireballSourceTransform;
    public float startTime = 0.25f;
    private float _shootTime;
    void Start()
    {
        _shootTime = 0;
    }
    void Update()
    {
        _shootTime -= Time.deltaTime;
        if (Input.GetMouseButton(0) && _shootTime <= 0)
        {
            var fireball = Instantiate(fireballPrefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
            fireball.damage = damage;
            _shootTime = startTime;
        }
        if (_shootTime <= 0) _shootTime = 0;
    }
}
