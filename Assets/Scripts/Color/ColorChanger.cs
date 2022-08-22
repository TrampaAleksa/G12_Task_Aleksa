using DefaultNamespace;
using UnityEngine;


/// <summary>
/// Changes the Color of the Currently selected Object (by changing its material) if any is Selected to the given <see cref="materialToApply"/>.
/// Uses the <see cref="ColorChangerCommand"/> to Execute the color change so that the Change can be <see cref="ICommand.Undo"/>'d later.
/// </summary>
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