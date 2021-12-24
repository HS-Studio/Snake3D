// GENERATED AUTOMATICALLY FROM 'Assets/SnakeMove.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @SnakeMove : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @SnakeMove()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""SnakeMove"",
    ""maps"": [
        {
            ""name"": ""control"",
            ""id"": ""b7e8bbb8-169c-4410-aa37-de3fc4406c0e"",
            ""actions"": [
                {
                    ""name"": ""m_MoveAction"",
                    ""type"": ""Button"",
                    ""id"": ""af85badb-16ad-4068-ac91-f2f8265a0b20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""70955e1a-897b-4bd0-9330-4657ef8ffd70"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""1ac81bbc-0f18-4965-8543-821054fd35ff"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""m_MoveAction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a1f6ef66-ddc0-41c3-bbf7-6e5da5a11c19"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""m_MoveAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""822519bb-004f-488d-9d07-858ca2394f94"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""m_MoveAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""12ed3827-d4ab-452f-baa1-dc09a7445c7e"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""m_MoveAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a63e3626-9972-4fba-bb59-7936e5f5de96"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""m_MoveAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""867aebe5-2c85-47f3-824b-97267b22ad27"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""m_MoveAction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7e9e7707-da89-410f-9f02-aa014acad2f2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""m_MoveAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""07b056cc-a47e-44e3-a80c-b279775a3941"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""m_MoveAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ae3a384e-2ebf-46a4-9fd5-980533028d1a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""m_MoveAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9267f838-95a5-40c3-8490-466bce1d63d8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""m_MoveAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""beda6677-42ee-4992-b936-b374c0e859e5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""m_MoveAction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""abe3c9b5-233c-4a52-95ac-bfda7c0fa127"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""m_MoveAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""94dcdf57-6f72-41d8-84fe-5fbb82757ec4"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""m_MoveAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""add9f1f5-ee3c-4bb4-a081-f0ccbabd9bd7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""m_MoveAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6dacb04f-a40b-4060-be76-2f7275ba7028"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""m_MoveAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""64834e21-ef82-42c3-ab48-f1851ea2d30a"",
                    ""path"": ""*/{Back}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // control
        m_control = asset.FindActionMap("control", throwIfNotFound: true);
        m_control_m_MoveAction = m_control.FindAction("m_MoveAction", throwIfNotFound: true);
        m_control_Pause = m_control.FindAction("Pause", throwIfNotFound: true);
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

    // control
    private readonly InputActionMap m_control;
    private IControlActions m_ControlActionsCallbackInterface;
    private readonly InputAction m_control_m_MoveAction;
    private readonly InputAction m_control_Pause;
    public struct ControlActions
    {
        private @SnakeMove m_Wrapper;
        public ControlActions(@SnakeMove wrapper) { m_Wrapper = wrapper; }
        public InputAction @m_MoveAction => m_Wrapper.m_control_m_MoveAction;
        public InputAction @Pause => m_Wrapper.m_control_Pause;
        public InputActionMap Get() { return m_Wrapper.m_control; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlActions set) { return set.Get(); }
        public void SetCallbacks(IControlActions instance)
        {
            if (m_Wrapper.m_ControlActionsCallbackInterface != null)
            {
                @m_MoveAction.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnM_MoveAction;
                @m_MoveAction.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnM_MoveAction;
                @m_MoveAction.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnM_MoveAction;
                @Pause.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_ControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @m_MoveAction.started += instance.OnM_MoveAction;
                @m_MoveAction.performed += instance.OnM_MoveAction;
                @m_MoveAction.canceled += instance.OnM_MoveAction;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public ControlActions @control => new ControlActions(this);
    public interface IControlActions
    {
        void OnM_MoveAction(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
