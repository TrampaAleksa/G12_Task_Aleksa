using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private Camera _camera;
    private RaycastHit _hit;

    private SelectableObject _selectedObj;
    private SelectableObject _nullObj;

    private void Start()
    {
        _camera = Camera.main;
        _nullObj = Instantiate(new GameObject("Null Object").AddComponent<SelectableObject>());
        _selectedObj = _nullObj;
    }

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        HandleMouseClickDown(ray);
        HandleMouseClickHold(ray);
        HandleMouseClickUp(ray);
    }

    private void HandleMouseClickDown(Ray ray)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!MouseOverSelectableObj(ray))
                return;
            _selectedObj = _hit.collider.GetComponent<SelectableObject>();
        }
    }
    private void HandleMouseClickHold(Ray ray)
    {
        if (!Input.GetKey(KeyCode.Mouse0))
            return;
        if (!MouseOverSelectableObj(ray))
            return;
        _selectedObj.UpdateSelection();
    }
    private void HandleMouseClickUp(Ray ray)
    {
        if (!Input.GetKeyUp(KeyCode.Mouse0))
            return;
        _selectedObj = _nullObj;
        print("Released Mouse Click");
    }

    

    private bool MouseOverSelectableObj(Ray ray)
    {
        return Physics.Raycast(ray, out _hit) && _hit.collider.CompareTag("Selectable");
    }
}