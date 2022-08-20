using System;
using DefaultNamespace;
using UnityEngine;

public class DraggableObjectMovement : MonoBehaviour
{
    // -------------- Movement Across Plane -------------- //
    
    private float dist;
    private Vector3 v3Offset;
    private Plane plane;
    public GameObject mainStructure;
    public float heightOffset = 0.5f;

    private Vector3 _initialPosition;

    void OnMouseDown() 
    {
        plane.SetNormalAndPosition(mainStructure.transform.up, mainStructure.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);     
        float dist;
        plane.Raycast(ray, out dist); 
        v3Offset = transform.position - ray.GetPoint(dist);

        _initialPosition = transform.position;
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
        var endPosition = transform.position;

        var movementCommand = new ObjectMovementCommand(
            _initialPosition,
            endPosition,
            gameObject);
        
        CommandManager.Instance.ExecuteCommand(movementCommand);
    }
}