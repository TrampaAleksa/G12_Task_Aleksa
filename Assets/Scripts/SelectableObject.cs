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
    
}