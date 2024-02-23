using System.Collections;
using UnityEngine;

public class DropStack : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(5);

        Destroy(gameObject);
    }
}