using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isAlive = true;

    public void Kill()
    {
        isAlive = false;
        StartCoroutine(nameof(Rebirth));
    }

    private IEnumerator Rebirth()
    {
        yield return new WaitForSeconds(0.75f);
        GetComponent<RagdollActivator>().enabled = false;
        yield return new WaitForSeconds(4);

        Vector3 pos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));

        transform.position = pos;
        isAlive = true;
        GetComponent<RagdollActivator>().enabled = true;

    }

    public bool IsAlive()
    {
        return isAlive;
    }
}
