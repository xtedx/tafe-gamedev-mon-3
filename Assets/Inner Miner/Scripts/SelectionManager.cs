using TeddyToolKit.Core;
using UnityEngine;

namespace Inner_Miner.Scripts
{
    public class SelectionManager : MonoSingleton<SelectionManager>
    {
        [SerializeField] private string selectableTag = "Selectable";
        [SerializeField] private Material highlightMaterial;

        private Material _originalMaterial;
        private GameObject _selectedObject;
        public void ClickAction(Vector2 pos)
        {
            //get the object clicked
            var pointedObject = getObjectOnMousePosition(pos);
            //ignore if new object same as currently selected object or nothing pointed
            if ((_selectedObject == pointedObject) || pointedObject == null) return;

            Debug.Log($"pointedObject.name {pointedObject.name}");

            //deselect
            Renderer r;
            if (_selectedObject != null && _originalMaterial != null)
            {
                r = _selectedObject.GetComponent<Renderer>();
                r.material = _originalMaterial;
                _selectedObject = null;
            }
            
            //select/highlight
            //store original material
            _selectedObject = pointedObject;
            r = _selectedObject.GetComponent<Renderer>();
            _originalMaterial = r.material;
            //highlight the clicked object
            r.material = highlightMaterial;
        }

        /// <summary>
        /// get the clicked object
        /// </summary>
        /// <returns>GameObject</returns>
        public GameObject getObjectOnMousePosition(Vector2 pos)
        {
            //3D
            RaycastHit rayHit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(pos);
            bool isHit = Physics.Raycast(ray, out rayHit);
            Debug.DrawRay(ray.origin, ray.direction * 50, Color.magenta, 1f);
            // Debug.Log($"mouse position: {pos} is 3d hit: {isHit}");
            if (isHit)
            {
                return rayHit.collider.gameObject;
            }

            //2D
            RaycastHit2D rayHit2D = Physics2D.GetRayIntersection(ray);
            //if (rayHit2D != null) //don't compare to null because it is never null, resharper hint.
            if (rayHit2D) //if there is no value then this will not be true, don't use null
            {
                // Debug.Log($"mouse position: {pos} is 2d hit: {rayHit2D.collider.gameObject.name}");
                return rayHit2D.collider.gameObject;
            }

            return null;
        }
    }
}