using DefaultNamespace;
using UnityEngine;

public class ColorChanger : MonoBehaviour, ICommand
{
    [SerializeField]
    private Material materialToApply;
    
    private Material _materialBeforeApplying;

    public void SaveState()
    {
        var objectColor =
            SelectionManager.Instance
                .SelectedObj.GetComponent<DraggableObjectColor>();

        _materialBeforeApplying = objectColor.CurrentMaterial;
    }
    public void Execute()
    {
        ChangeColor(materialToApply);
    }
    public void Undo()
    {
        ChangeColor(_materialBeforeApplying);
    }
    public void ChangeColor()
    {
        CommandManager.Instance.ExecuteCommand(this);
    }
    
    private void ChangeColor(Material toChangeTo)
    {
        var objectColor =
            SelectionManager.Instance
                .SelectedObj.GetComponent<DraggableObjectColor>();
        
        objectColor.CurrentMaterial = toChangeTo;
        objectColor.ChangeMaterial(toChangeTo);
    }
}