using System;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{

    
   //todo - split move logic from color logic

    // -------------- Movement Across Plane -------------- //
    private float dist;
    private Vector3 v3Offset;
    private Plane plane;
    public GameObject mainStructure;
    public float heightOffset = 0.5f;

    private void Awake()
    {
        CurrentMaterial = GetComponent<Renderer>().material;
    }

    void OnMouseDown() 
    {
        SelectionManager.Instance.SelectedObj = this;
        
        plane.SetNormalAndPosition(mainStructure.transform.up, mainStructure.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);     
        float dist;
        plane.Raycast(ray, out dist); 
        v3Offset = transform.position - ray.GetPoint(dist);
        
        
        ChangeMaterial(materialWhileSelected);
    }

    void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float dist;
        plane.Raycast(ray, out dist);    
        Vector3 v3Pos = ray.GetPoint(dist);    
        Vector3 lastPos = v3Pos + v3Offset;      
        transform.position = plane.ClosestPointOnPlane(lastPos) + Vector3.up*heightOffset;  
    }

    private void OnMouseUp()
    {
        ChangeMaterial(CurrentMaterial);
    }


    [SerializeField]
    private Material materialWhileSelected;
    public Material CurrentMaterial { get; set; }
  
    public void ChangeMaterial(Material materialToApply)
    {
        gameObject.GetComponent<Renderer>().material = materialToApply;
    }

}