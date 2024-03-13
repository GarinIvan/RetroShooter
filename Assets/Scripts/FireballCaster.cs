using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public Fireball fireballPrefab;
    public Transform fireballSourceTransform;
    public float startTime = 1;
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
            Instantiate(fireballPrefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
            _shootTime = startTime;
        }
    }
}
