using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineHighlighter : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float highlightThickness = 0.012f;
    [SerializeField] float highlightSpeed = 10f; // Kecepatan highlight
    [SerializeField] float unhighlightSpeed = 20f; // Kecepatan unhighlight

    private float targetThickness = 0f;
    private float currentThickness = 0f;



    void Update()
    {
        // Interpolasi nilai currentThickness ke targetThickness
        float speed = targetThickness > currentThickness ? highlightSpeed : unhighlightSpeed;
        currentThickness = Mathf.Lerp(currentThickness, targetThickness, Time.deltaTime * speed);
        spriteRenderer.material.SetFloat("_Thickness", currentThickness);
    }

    public void Highlight()
    {
        targetThickness = highlightThickness;
    }

    public void Unhighlight()
    {
        targetThickness = 0f;
    }
}
