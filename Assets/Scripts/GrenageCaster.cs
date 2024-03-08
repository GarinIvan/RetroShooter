using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenageCaster : MonoBehaviour
{
    public Rigidbody grenadePrefab;
    public Transform granadeSourceTransform;
    public float force = 10;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var grenade = Instantiate(grenadePrefab);
            grenade.transform.position = granadeSourceTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(granadeSourceTransform.forward * force * 0.5f);
            grenade.GetComponent<Rigidbody>().AddForce(granadeSourceTransform.up * force);
        }
    }
}
