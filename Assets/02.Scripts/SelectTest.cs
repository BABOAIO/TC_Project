using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SelectTest : MonoBehaviour
{
    Material outline;
    Renderer renderers;

    List<Material> materialList = new List<Material>();

    void Start()
    {
        outline = new Material(Shader.Find("Draw/Outline"));
    }

    void Update()
    {

    }

    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        if (args.interactable.transform.CompareTag("SELECTABLE"))
        {
            renderers = this.GetComponent<Renderer>();

            materialList.Clear();
            materialList.AddRange(renderers.sharedMaterials);
            materialList.Add(outline);

            renderers.materials = materialList.ToArray();
        }
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        if (args.interactable.transform.CompareTag("SELECTABLE"))
        {
            Renderer renderer = this.GetComponent<Renderer>();

            materialList.Clear();
            materialList.AddRange(renderer.sharedMaterials);
            materialList.Remove(outline);

            renderer.materials = materialList.ToArray();
        }
    }
}
