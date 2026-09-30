using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 0.5f;
    [SerializeField] float shakeMagnitute = 0.5f;

    Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(ShakeCamera());
    }

    IEnumerator ShakeCamera()
    {
        float timeElapsed = 0f;
        
        while (timeElapsed < shakeDuration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitute;
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = initialPosition;
    }
}
