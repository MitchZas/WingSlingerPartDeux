using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class ScaleChange : MonoBehaviour
{
    public Vector3 triggerScale = new Vector3(1.1f, 1.1f, 1.1f);
    public Vector3 originalScale = new Vector3(1.7f, 1.7f, 1.7f);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Customer"))
        {
            other.gameObject.transform.localScale = triggerScale;
        }

        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.localScale = triggerScale;
            Debug.Log(triggerScale);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Customer"))
        {
            other.gameObject.transform.localScale = originalScale;
        }

        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.localScale = originalScale;
        }
    }
}
