using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour
{
    public Light light;

    public void ScaleIntensity(float targetIntensity, float duration)
    {
        StartCoroutine(ChangeIntensityOverTime(targetIntensity, duration));
    }

    IEnumerator ChangeIntensityOverTime(float targetIntensity, float duration)
    {
        float initialIntensity = light.intensity;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float newIntensity = Mathf.Lerp(initialIntensity, targetIntensity, elapsed / duration);
            light.intensity = newIntensity;

            elapsed += Time.deltaTime;
            yield return null;
        }

        light.intensity = targetIntensity;
    }
}