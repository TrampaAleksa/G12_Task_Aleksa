using System;
using DefaultNamespace;
using UnityEngine;

/// <summary>
/// Used to Move an Object by dragging it with the Mouse.
/// Uses the <see cref="CommandManager"/> to execute every drag
/// as a <see cref="ICommand"/> to allow for <see cref="ICommand.Undo"/> logic.
/// </summary>
public class DraggableObjectMovement : MonoBehaviour
{
    // -------------- Movement Across Plane -------------- //
    
    private float dist;
    private Vector3 v3Offset;
    private Plane plane;
    public GameObject mainStructure;
    public float heightOffset = 0.5f;

    // ---------------- Movement Command ------------------ //
    private Vector3 _initialPosition;

    void OnMouseDown()
    {
        PrepareForDrag();
        PrepareMovementCommand();
    }
    void OnMouseDrag()
    {
        DragObject();
    }
    private void OnMouseUp()
    {
        if (ObjectInsidePlaneCheck())
            ExecuteMovementCommand();
    }

    private void PrepareForDrag()
    {
        plane.SetNormalAndPosition(mainStructure.transform.up, mainStructure.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float dist;
        plane.Raycast(ray, out dist);
        v3Offset = transform.position - ray.GetPoint(dist);
    }

    /// <summary>
    /// Saves the position when the drag started so that <see cref="ICommand.Undo"/> can return the object to that position.
    /// </summary>
    private void PrepareMovementCommand()
    {
        _initialPosition = transform.position;
    }

    private void DragObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float dist;
        plane.Raycast(ray, out dist);
        Vector3 v3Pos = ray.GetPoint(dist);
        Vector3 lastPos = v3Pos + v3Offset;
        transform.position = plane.ClosestPointOnPlane(lastPos) + Vector3.up * heightOffset;
    }

    private void ExecuteMovementCommand()
    {
        var endPosition = transform.position;

        var movementCommand = new ObjectMovementCommand(
            _initialPosition,
            endPosition,
            gameObject);

        CommandManager.Instance.ExecuteCommand(movementCommand);
    }

    public bool ObjectInsidePlaneCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 5, LayerMask.GetMask("Plane")))
            return true;
            
        transform.position = _initialPosition;
        return false;
    }
}