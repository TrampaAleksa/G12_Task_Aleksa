using DefaultNamespace;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    private Material materialToApply;
    public void ChangeColor()
    {
        var objectColor =
            SelectionManager.Instance
                .SelectedObj.GetComponent<DraggableObjectColor>();
        
        objectColor.CurrentMaterial = materialToApply;
        objectColor.ChangeMaterial(materialToApply);
    }
}