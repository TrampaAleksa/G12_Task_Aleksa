using DefaultNamespace;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    private Material materialToApply;

    public void ChangeColor()
    {
        if (ObjectNotSelected())
            return;

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

    private static bool ObjectNotSelected()
    {
        var isNull = SelectionManager.Instance
            .SelectedObj.name == "Null Object";
        if (isNull)
        {
            Debug.Log("Can't change color: No Object was selected");
            return true;
        }
        return false;
    }
}