using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObject : MonoBehaviour
{
    public List<MeshRenderer> meshes;
    public Material onMaterial, transparentMat, outliner, wrench;
    public GameObject currentObj;
    public float timero;
    public Transform[] parents;
    void Start()
    {
        for (int i = 0; i < parents.Length; i++)
        {
            MeshRenderer[] renderers = parents[i].GetComponentsInChildren<MeshRenderer>();
            foreach (var rend in renderers)
            {
                meshes.Add(rend);
            }
        }
    }

    public void MakeTransparent()
    {
        StartCoroutine(KeepTransparent());
    }


    IEnumerator KeepTransparent()
    {
        for (int i = 0; i < meshes.Count; i++)
        {
            meshes[i].material = transparentMat;
        }
        MeshRenderer[] renderers = currentObj.GetComponentsInChildren<MeshRenderer>();
        foreach (var rend in renderers)
        {
            rend.material = outliner;
        }
        yield return new WaitForSeconds(timero);
        for (int i = 0; i < meshes.Count; i++)
        {
            if (!meshes[i].gameObject.GetComponent<UseScrew>())
                meshes[i].material = onMaterial;
            else meshes[i].material = wrench;
        }
    }

    public void DisplayUI(bool turnItOn)
    {
        if (turnItOn)
        {
            for (int i = 0; i < meshes.Count; i++)
            {
                meshes[i].material = transparentMat;
            }
            MeshRenderer[] renderers = currentObj.GetComponentsInChildren<MeshRenderer>();
            foreach (var rend in renderers)
            {
                rend.material = outliner;
            }
        }
        else
        {
            for (int i = 0; i < meshes.Count; i++)
            {
                if (!meshes[i].gameObject.GetComponent<UseScrew>())
                    meshes[i].material = onMaterial;
                else meshes[i].material = wrench;
            }
        }
    }
}
