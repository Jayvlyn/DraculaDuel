//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.1
//     from Assets/ML-Agents/Examples/PushBlockWithInput/PushBlockActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PushBlockActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PushBlockActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PushBlockActions"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""03a2e5d4-ae81-47f1-a575-0779fb7da538"",
            ""actions"": [
                {
                    ""name"": ""movement"",
                    ""type"": ""Value"",
                    ""id"": ""5f47cbc6-de46-4d33-93e2-2b1af4f5996d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""ca5eb833-5dfb-4b7c-880d-6118bd5d1378"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""gamepad_move"",
                    ""id"": ""477500ef-6d32-4b84-b9f8-158f18bcb906"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6d2537b8-2266-4a50-8575-fb0fe310daa5"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""50584c83-beb6-4e90-a453-a635c03a761e"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""44408b8f-27e7-4c6d-b078-7536ba020d1a"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f5681423-d3e3-41a5-b85e-0a7642c774aa"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""keyboard_move"",
                    ""id"": ""6bcba4bf-5ce0-4005-9e6a-0de2487211b0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""63da699e-b354-4e63-b0f8-26fb92abea41"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""39409748-9002-4aff-9a09-cdc05b9708ad"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0afe45fc-dc45-4310-9c73-7dc3c503addf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""69fe0335-9e0c-495d-a90d-4b0fcbfd2b34"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ab696218-63cd-4eb8-9fe1-48a68e32e92f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7adcb138-5175-4cc4-addc-d2b02cb5f0de"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_movement = m_Movement.FindAction("movement", throwIfNotFound: true);
        m_Movement_jump = m_Movement.FindAction("jump", throwIfNotFound: true);
    }

    ~@PushBlockActions()
    {
        UnityEngine.Debug.Assert(!m_Movement.enabled, "This will cause a leak and performance issues, PushBlockActions.Movement.Disable() has not been called.");
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private List<IMovementActions> m_MovementActionsCallbackInterfaces = new List<IMovementActions>();
    private readonly InputAction m_Movement_movement;
    private readonly InputAction m_Movement_jump;
    public struct MovementActions
    {
        private @PushBlockActions m_Wrapper;
        public MovementActions(@PushBlockActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @movement => m_Wrapper.m_Movement_movement;
        public InputAction @jump => m_Wrapper.m_Movement_jump;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void AddCallbacks(IMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_MovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovementActionsCallbackInterfaces.Add(instance);
            @movement.started += instance.OnMovement;
            @movement.performed += instance.OnMovement;
            @movement.canceled += instance.OnMovement;
            @jump.started += instance.OnJump;
            @jump.performed += instance.OnJump;
            @jump.canceled += instance.OnJump;
        }

        private void UnregisterCallbacks(IMovementActions instance)
        {
            @movement.started -= instance.OnMovement;
            @movement.performed -= instance.OnMovement;
            @movement.canceled -= instance.OnMovement;
            @jump.started -= instance.OnJump;
            @jump.performed -= instance.OnJump;
            @jump.canceled -= instance.OnJump;
        }

        public void RemoveCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_MovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
