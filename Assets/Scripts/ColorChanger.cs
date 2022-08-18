using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    private Material materialToApply;
    public void ChangeColor()
    {
        SelectionManager.Instance.SelectedObj.GetComponent<Renderer>().material = materialToApply;
    }
}