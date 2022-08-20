using System;
using com.snd.plugin;
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

        public void TemporaryColor(float duration)
        {
            ChangeMaterial(materialWhileSelected);
            gameObject.AddComponent<TimedAction>().StartTimedAction(() => ChangeMaterial(CurrentMaterial), duration);
        }
    }
}