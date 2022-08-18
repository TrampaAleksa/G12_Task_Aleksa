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

        ColorChangerCommand command =
            new ColorChangerCommand(
                objectColor.CurrentMaterial,
                materialToApply,
                objectColor.gameObject);
        
        CommandManager.Instance.ExecuteCommand(command);
    }
}