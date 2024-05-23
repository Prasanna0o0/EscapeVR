using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAssigner : MonoBehaviour
{
    // Start is called before the first frame update
    public Material material; // Reference to your material
    public Texture2D imageTexture; // Texture you want to assign

    void Start()
    {
        if (material != null && imageTexture != null)
        {
            // Set the texture property of the material
            material.SetTexture("_MainTex", imageTexture);

            // Access the MeshRenderer component of the GameObject
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

            if (meshRenderer != null)
            {
                // Assign the material to the MeshRenderer
                meshRenderer.material = material;
            }
            else
            {
                Debug.LogError("MeshRenderer component not found!");
            }
        }
        else
        {
            Debug.LogError("Material or Image Texture not assigned!");
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
