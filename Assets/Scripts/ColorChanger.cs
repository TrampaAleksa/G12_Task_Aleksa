using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    private Material materialToApply;
    public void ChangeColor()
    {
        SelectionManager.Instance.SelectedObj.CurrentMaterial = materialToApply;
        SelectionManager.Instance.SelectedObj.ChangeMaterial(materialToApply);
    }
}