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

        /// <summary>
        /// Used to change the color of the object to the <see cref="materialWhileSelected"/> color during the given time.
        /// Then returns the color to the objects <see cref="CurrentMaterial"/> after it's finished.
        /// </summary>
        /// <param name="duration"></param>
        public void TemporaryColor(float duration)
        {
            ChangeMaterial(materialWhileSelected);
            gameObject.AddComponent<TimedAction>().StartTimedAction(() => ChangeMaterial(CurrentMaterial), duration);
        }
    }
}