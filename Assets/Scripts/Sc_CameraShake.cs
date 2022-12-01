using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_CameraShake : MonoBehaviour
{
    public bool isShaking;
    public AnimationCurve curve;
    public float duration = 0.2f;
    // Start is called before the first frame update
    void Update()
    {
        if(isShaking){
            isShaking = false;
            StartCoroutine(Shake());
        }
    }

    IEnumerator Shake(){
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while(elapsedTime < duration){
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime/duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }
}
