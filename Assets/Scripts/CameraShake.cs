using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }
    
    IEnumerator Shake()
    {
        float elapsedTime = 0;

        while (elapsedTime < shakeDuration)
        {
        //This would have issues as initialPosition is vector3 but insideUnitCircle is vector2, so either we turn insideUnitCircle into a vector3 or we make it insideUnitSphere instead
        transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;

        elapsedTime += Time.deltaTime;
        yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
    }
}
