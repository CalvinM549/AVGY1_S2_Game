using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimation : MonoBehaviour
{

    public AnimationCurve warningCurve;
    Vector3 endSize;
    float explosionTime;

    IEnumerator CoolAnimation()
    {
        Vector3 startScale = Vector3.zero;
        Vector3 currentScale = startScale;
        float t = 0;
        while(t < 1)
        {
            t += Time.deltaTime;
            float warningValue = t / explosionTime;
            currentScale = Vector3.Lerp(startScale, endSize, warningCurve.Evaluate(warningValue));
            transform.localScale = currentScale;
            yield return null;
        }

        Destroy(gameObject);  
    }

    public void SetValues(Vector3 end, float speed)
    {
        Debug.Log("Set Values");

        endSize = end;
        explosionTime = speed;
        StartCoroutine(CoolAnimation());
    }
}
