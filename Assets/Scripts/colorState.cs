using UnityEngine;

public class colorState : MonoBehaviour
{
    public ColorManager.StandardColor color;
    public Renderer colorRenderer;
    public bool colorShift = true;
    // when colorShift = true, it is on redShift, and when colorShift = false, it is on blueShift

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()

    {
        colorRenderer = GetComponentInChildren<Renderer>();

       // colorRenderer.material = ColorManager.singleton.standardMattes[(int)color];
    }
    

    
    // Update is called once per frame
    void Update()
    {

        if (colorShift)
        {
            colorRenderer.material.SetColor("_BaseColor", new Color(0f,0f,1f,0.25f));
            colorRenderer.material.SetColor("_EmissionColor", new Color(0f, 0f, 1f, 0.25f));

        }
        else
        {
            colorRenderer.material.SetColor("_BaseColor", Color.blue);
            colorRenderer.material.SetColor("_EmissionColor", Color.blue);
        }
    }
}
