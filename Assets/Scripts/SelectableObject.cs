using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    // -------------- Movement Across Plane -------------- //
    private float dist;
    private Vector3 v3Offset;
    private Plane plane;
    public GameObject mainStructure;
    public float heightOffset = 0.5f;
 
    void OnMouseDown()
    {
        SelectionManager.Instance.SelectedObj = this;
        
        plane.SetNormalAndPosition(mainStructure.transform.up, mainStructure.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);     
        float dist;
        plane.Raycast(ray, out dist); 
        v3Offset = transform.position - ray.GetPoint(dist);
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
}