using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Stars : MonoBehaviour
{
    int currentStarIndex = 0;
    float timer = 0;

    public List<Transform> starTransforms;
    public float drawingTime;

    // Update is called once per frame
    void Update()
    { 
        DrawConstellation();
    }

    public void DrawConstellation()
    {
        Transform currentStar = starTransforms[currentStarIndex];
        Transform nextStar = starTransforms[(currentStarIndex + 1) % starTransforms.Count];

        timer += Time.deltaTime;

        float t = Mathf.Clamp01(timer / drawingTime);

        Vector3 currentPoint = Vector3.Lerp(currentStar.position, nextStar.position, t);

        Debug.DrawLine(currentStar.position, currentPoint);

        if (timer >= drawingTime)
        {
            timer = 0;
            currentStarIndex = (currentStarIndex + 1) % starTransforms.Count;
        }
    }
}
