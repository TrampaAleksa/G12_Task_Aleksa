using UnityEngine;

internal class SelectableObject : MonoBehaviour
{
    public void StartSelection()
    {
        print("Selected object: " + gameObject.name);
    }

    public void UpdateSelection()
    {
        print("Holding mouse over selected object: " + gameObject.name);
    }

    public void EndSelection()
    {
        print("Unselected object: " + gameObject.name);
    }

    public void ChangeColor(ColorChanger colorChanger)
    {
        colorChanger.ChangeColor(this);
    }
    
    
    // -------------- Movement Across Plane -------------- //
    private float dist;
    private Vector3 v3Offset;
    private Plane plane;
    public GameObject mainStructure;
    public float heightOffset = 0.5f;
 
    void OnMouseDown()
    {
      
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