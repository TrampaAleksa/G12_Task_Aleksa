using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class DraggableObjectColor : MonoBehaviour
    {
        [SerializeField]
        private Material materialWhileSelected;
        [NonSerialized]
        public Material CurrentMaterial;
        
        private void Awake()
        {
            CurrentMaterial = GetComponent<Renderer>().material;
        }

        private void OnMouseDown()
        {
            ChangeMaterial(materialWhileSelected);

        }
        private void OnMouseUp()
        {
            ChangeMaterial(CurrentMaterial);
        }

        public void ChangeMaterial(Material materialToApply)
        {
            gameObject.GetComponent<Renderer>().material = materialToApply;
        }
    }
}