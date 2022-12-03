using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    public float shakeSpeed = 10f;
    public float shakeAmount = 2f;

    private bool shake = false;

    // Update is called once per frame
    void Update()
    {
        if (shake)
        {
            ShakeObjects();
        }
    }

    private void ShakeObjects()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, LayerMask.GetMask("Target"));
        foreach (Collider hit in hitColliders)
        {
            hit.transform.Rotate(Mathf.Sin(Time.time * shakeSpeed) * shakeAmount * Time.deltaTime, 0f, 0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hammer"))
        {
            shake = true;
        }
    }
}
