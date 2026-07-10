using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class colorState : MonoBehaviour
{

    public Renderer colorRenderer;

    public bool colorShift = true;
    public bool isBlue = false;
    public bool enableCollision = false;
    public Collider collisions;

    InputAction shiftColors;

    // when colorShift = true, it is on redShift, and when colorShift = false, it is on blueShift

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()

    {
        shiftColors = InputSystem.actions.FindAction("Shift");

        colorRenderer = GetComponentInChildren<Renderer>();

        //collision thingy woah

        collisions = GetComponentInChildren<Collider>();

       //colorRenderer.material = ColorManager.singleton.standardMattes[(int)color]; <- useless garbage meh meh meh 
    }
    

    
    // Update is called once per frame
    void Update()
    {
        // Collision updater

        collisions.enabled = enableCollision;


        if (shiftColors.WasCompletedThisFrame())
        {
            colorShift = !colorShift;
        }
        

        if (colorShift)
        {
            if (isBlue)
            {
                //blue transparent stuff

                Material[]mats = colorRenderer.materials;

                mats[0].SetColor("_BaseColor", new Color(0f, 0f, 1f, 0.25f));
                mats[1].SetColor("_BaseColor", new Color(0f, 0f, 1f, 0.25f));
                mats[0].SetColor("_EmissionColor", new Color(0f, 0f, 1f, 0.25f));
                mats[1].SetColor("_EmissionColor", new Color(0f, 0f, 1f, 0.25f));

                colorRenderer.materials = mats;
                
                enableCollision = false;
            } else
            {
                //red solid stuff

                Material[] mats = colorRenderer.materials;

                mats[0].SetColor("_BaseColor", Color.red);
                mats[1].SetColor("_BaseColor", Color.red);
                mats[0].SetColor("_EmissionColor", Color.red);
                mats[1].SetColor("_EmissionColor", Color.red);

                colorRenderer.materials = mats;

                enableCollision = true;
            }
        }
        else
        {
            if(isBlue)
            {
                //blue solid stuff

                Material[] mats = colorRenderer.materials;

                mats[0].SetColor("_BaseColor", Color.blue);
                mats[1].SetColor("_BaseColor", Color.blue);
                mats[0].SetColor("_EmissionColor", Color.blue);
                mats[1].SetColor("_EmissionColor", Color.blue);

                colorRenderer.materials = mats;

                enableCollision = true;
            } else
            {
                //red transparent stuff

                Material[] mats = colorRenderer.materials;

                mats[0].SetColor("_BaseColor", new Color(1f, 0f, 0f, 0.25f));
                mats[1].SetColor("_BaseColor", new Color(1f, 0f, 0f, 0.25f));
                mats[0].SetColor("_EmissionColor", new Color(1f, 0f, 0f, 0.25f));
                mats[1].SetColor("_EmissionColor", new Color(1f, 0f, 0f, 0.25f));

                colorRenderer.materials = mats;

                enableCollision = false;
            }
        }
    }
}
