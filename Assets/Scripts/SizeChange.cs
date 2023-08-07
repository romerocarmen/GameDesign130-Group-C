using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChange : MonoBehaviour
{
    [Header("Control Settings")]
    [SerializeField] private float origScale = 1f; 
    [SerializeField] private float maxScale = 1.5f;
    [SerializeField] private float minScale = .5f;
    [SerializeField] private float changeSpeed = .01f;

    [Header("Runtime Settings")]
    [SerializeField] private float scale = 1f;
    [SerializeField] private float targetMax = 0f;
    [SerializeField] private float targetMin = 0f;
    [SerializeField] private bool startsDecreasing = true;

    // Start is called before the first frame update
    void Start()
    {
        scale = origScale;
        startsDecreasing = randomBoolean();
        StartCoroutine(SizeOscillation());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // increase scale to a random amount up to the max scale
    // shrink down to reg scale
    // decrease scale to random amount up to min scale
    // repeat
    // I HATE COROUTINES I HATE COURUTINES I HATE COROUTINES
    IEnumerator SizeOscillation()
    {
        if (startsDecreasing)
        {
            setTargetScales();
            while (scale > minScale)
            {
                scale -= changeSpeed * Time.deltaTime;
                transform.localScale = new Vector2(scale, scale);

                yield return null;
            }
            startsDecreasing = false;
        }

        // set random scale targets
        setTargetScales();

        // scale to target max
        while (scale < targetMax)
        {
            scale += changeSpeed * Time.deltaTime;
            transform.localScale = new Vector2(scale, scale);

            yield return null;
        }
        // scale to neutral
        while (scale > origScale)
        {
            scale -= changeSpeed * Time.deltaTime;
            transform.localScale = new Vector2(scale, scale);

            yield return null;
        }
        // scale to min scale
        while (scale > minScale)
        {
            scale -= changeSpeed * Time.deltaTime;
            transform.localScale = new Vector2(scale, scale);

            yield return null;
        }

        StartCoroutine(SizeOscillation());
    }

    private void setTargetScales()
    {
        targetMax = UnityEngine.Random.Range(scale, maxScale);
        targetMin= UnityEngine.Random.Range(scale, minScale);
    }

    private bool randomBoolean()
    {

        return (UnityEngine.Random.value > 0.5f);

    }
}
