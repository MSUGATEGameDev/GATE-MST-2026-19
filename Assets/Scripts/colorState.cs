using UnityEngine;

public class colorState : MonoBehaviour
{
    public ColorManager.StandardColor color;
    public Renderer colorRenderer;
    bool colorShift = true;
    // when colorShift = true, it is on redShift, and when colorShift = false, it is on blueShift

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()

    {
        colorRenderer = GetComponentInChildren<Renderer>();

        colorRenderer.material = ColorManager.singleton.standardMattes[(int)color];
    }
    

    
    // Update is called once per frame
    void Update()
    {

        if (colorShift)
        {
            colorRenderer.material.SetColor("_BaseColor", Color.azure);
            colorRenderer.material.SetColor("_EmissionColor", Color.azure);

        }
        else
        {

        }
    }
}
