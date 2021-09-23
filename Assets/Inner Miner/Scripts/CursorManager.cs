using TeddyToolKit.Core;
using UnityEditor;
using UnityEngine;

namespace Inner_Miner.Scripts
{
    public class CursorManager : MonoSingleton<CursorManager>
    {
        private CursorControl _cursorControl;
        public Texture2D cursor;
        public Texture2D cursorPressed;

        private void Awake()
        {
            _cursorControl = new CursorControl();
        }

        private void OnEnable()
        {
            _cursorControl.Enable();
        }

        private void OnDisable()
        {
            _cursorControl.Disable();
        }

        // Start is called before the first frame update
        void Start()
        {
            _cursorControl.Mouse.Click.started += context => startedClick();
            _cursorControl.Mouse.Click.performed += context => performedClick();
            setCursor(cursor);
        }

        private void startedClick()
        {
            Debug.Log("started click");
            setCursor(cursorPressed);
        }

        private void performedClick()
        {
            Debug.Log("performed click");
            setCursor(cursor); // go back to normal cursor after click finished
            //pass the mouse position in the Aim action
            SelectionManager.Instance.ClickAction(_cursorControl.Mouse.Aim.ReadValue<Vector2>());
        }
        public void setCursor(Texture2D cursor)
        {
            //if the hotspot is in the centre, i.e. a crosshair cursor, then use this
            //var hotSpot = new Vector2(cursor.width / 2, cursor.height / 2);
            var hotSpot = Vector2.zero; //use top left corner
            //auto means auto hardware accelleration
            Cursor.SetCursor(cursor, hotSpot, CursorMode.Auto);
            Cursor.lockState = CursorLockMode.Confined;
            Debug.Log("cursor set");
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
