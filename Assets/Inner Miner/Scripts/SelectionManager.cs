using TeddyToolKit.Core;
using UnityEngine;

namespace Inner_Miner.Scripts
{
    /// <summary>
    /// Handles the Selection and Deselection of objects
    /// </summary>
    public class SelectionManager : MonoSingleton<SelectionManager>
    {
        [SerializeField] private string selectableTag = "Selectable";
        [SerializeField] private Material highlightMaterial;

        private Material _originalMaterial;
        public GameObject selectedObject;

        /// <summary>
        /// highlights the object on the mouse cursor, and remove 
        /// </summary>
        /// <param name="pos"></param>
        public void AimAction(Vector2 pos)
        {
            //get the object clicked
            var pointedObject = getObjectOnMousePosition(pos);
            //ignore if new object same as currently selected object or nothing pointed
            if ((selectedObject == pointedObject)
                || (pointedObject == null)
                || !pointedObject.CompareTag(selectableTag)) return;

            Debug.Log($"pointedObject.name {pointedObject.name}");

            //deselect
            Renderer r;
            if (selectedObject != null && _originalMaterial != null)
            {
                r = selectedObject.GetComponent<Renderer>();
                r.material = _originalMaterial;
                selectedObject = null;
            }
            
            //select/highlight
            //store original material
            selectedObject = pointedObject;
            r = selectedObject.GetComponent<Renderer>();
            _originalMaterial = r.material;
            //highlight the pointed object
            r.material = highlightMaterial;
        }
        
        /// <summary>
        /// Get the pointed object
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