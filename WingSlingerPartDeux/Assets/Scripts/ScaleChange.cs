using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class ScaleChange : MonoBehaviour
{
    public Vector3 triggerScale = new Vector3(.5f, .75f, 1f);
    public Vector3 originalScale = new Vector3(.5f, 1f, 1f);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Customer"))
        {
            other.gameObject.transform.localScale = triggerScale;
        }

        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.localScale = triggerScale;
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
