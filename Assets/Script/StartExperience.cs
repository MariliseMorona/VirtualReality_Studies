using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class StartExperience : MonoBehaviour
{
    [SerializeField] private GameObject cube;

    public void OnStratExperiente(ARPlane plane)
    {
        var scene = Instantiate(cube, plane.center, Quaternion.identity);

        for (int i = 0; i < scene.transform.childCount; i++)
        {
            var child = scene.transform.GetChild(i).gameObject;
            StartCoroutine(ScaleUp(child, 0.5f));
        }
    }

    IEnumerator ScaleUp(GameObject obj, float duration)
    {
        Vector3 initialScale = Vector3.zero;
        Vector3 targetScale = obj.transform.localScale;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            obj.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
