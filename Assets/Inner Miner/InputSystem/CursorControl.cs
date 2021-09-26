// GENERATED AUTOMATICALLY FROM 'Assets/TeddyToolKit/PointClick/InputHandler/CursorControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CursorControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CursorControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CursorControl"",
    ""maps"": [
        {
            ""name"": ""Mouse"",
            ""id"": ""4d9cf525-cce8-4f8c-b939-db05e80f6ff3"",
            ""actions"": [
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""b4b5c619-3458-469f-84cf-526e8e11cb6a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""9a0bd214-399c-419a-a396-3b11c0697ae1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3743aa27-cb15-4c1c-865d-8b1e7e3b8d7a"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a745aa1-f888-4121-af73-6ec575fe8825"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_Aim = m_Mouse.FindAction("Aim", throwIfNotFound: true);
        m_Mouse_Click = m_Mouse.FindAction("Click", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_Aim;
    private readonly InputAction m_Mouse_Click;
    public struct MouseActions
    {
        private @CursorControl m_Wrapper;
        public MouseActions(@CursorControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Aim => m_Wrapper.m_Mouse_Aim;
        public InputAction @Click => m_Wrapper.m_Mouse_Click;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @Aim.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnAim;
                @Click.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnClick;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);
    public interface IMouseActions
    {
        void OnAim(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
    }
}
