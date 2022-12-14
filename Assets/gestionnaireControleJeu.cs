//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.1
//     from Assets/gestionnaireControleJeu.inputactions
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

public partial class @GestionnaireControleJeu : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GestionnaireControleJeu()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""gestionnaireControleJeu"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""34519c02-e148-4a79-bb80-8766206ba9ce"",
            ""actions"": [
                {
                    ""name"": ""Deplacement"",
                    ""type"": ""Value"",
                    ""id"": ""8cbcc1bb-d75e-49ea-b14a-f5dedff05cd4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Tir"",
                    ""type"": ""Button"",
                    ""id"": ""01ffd854-a66c-4386-a4c3-e092699c0655"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""e766ca52-2025-4dbc-9685-88ad46a6ae6c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shield"",
                    ""type"": ""Button"",
                    ""id"": ""c100489e-f26e-461f-a56c-4431f6b3144d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShieldSurcharge"",
                    ""type"": ""Button"",
                    ""id"": ""e58b8cb4-b80c-4ac1-a41d-8adac1de5cdf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slow"",
                    ""type"": ""Button"",
                    ""id"": ""cc2d35e8-ecb5-4fe8-b14f-3b4f021a1248"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""zqsd"",
                    ""id"": ""bd93dcb4-18cd-41fa-92f7-e40855c7d0d4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3ad312d9-1a0d-49e6-9f9c-c3215790745e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""aa49b358-55d2-475d-9419-19ad5ac522e3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d75ba83c-f592-41f0-bfec-e595da758584"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2fd77094-06aa-405b-b0d0-82464756f4a6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""arrows"",
                    ""id"": ""502a6637-3cc9-4bc5-a4cb-10e0e1f9774e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""95434588-7213-4058-8469-7158bde52744"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""65c05d2f-45c6-430f-8eeb-2b319b186d71"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""243ec870-23f3-4518-bd06-5ec79080813b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""92c7ba54-4b02-46ef-a187-fcee736cf379"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1f304f91-201a-4622-94c3-4a71b91827c6"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49f4af69-7d00-4f35-9b47-8ae4567e40ee"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""471476ae-f0cc-447a-9671-0b2a012816ce"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b7612c5-c381-4d20-b957-45dcc3985639"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShieldSurcharge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9eae9dea-74ce-4c76-9b7e-4c1bfcb5d391"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ControlMenu"",
            ""id"": ""01ae5739-cd2a-4cfc-a87a-648856c5f742"",
            ""actions"": [
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""53c8cbaf-72b7-4fa3-a457-812482c26179"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""C"",
                    ""type"": ""Button"",
                    ""id"": ""aff01cb1-3532-410d-9df0-1ff1ef468cf9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7acd502c-0593-44ed-b727-da31a50408d6"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f53ec31-e7e3-4e6c-852b-fabe3d70c418"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""C"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Deplacement = m_Player.FindAction("Deplacement", throwIfNotFound: true);
        m_Player_Tir = m_Player.FindAction("Tir", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_Shield = m_Player.FindAction("Shield", throwIfNotFound: true);
        m_Player_ShieldSurcharge = m_Player.FindAction("ShieldSurcharge", throwIfNotFound: true);
        m_Player_Slow = m_Player.FindAction("Slow", throwIfNotFound: true);
        // ControlMenu
        m_ControlMenu = asset.FindActionMap("ControlMenu", throwIfNotFound: true);
        m_ControlMenu_Enter = m_ControlMenu.FindAction("Enter", throwIfNotFound: true);
        m_ControlMenu_C = m_ControlMenu.FindAction("C", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Deplacement;
    private readonly InputAction m_Player_Tir;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_Shield;
    private readonly InputAction m_Player_ShieldSurcharge;
    private readonly InputAction m_Player_Slow;
    public struct PlayerActions
    {
        private @GestionnaireControleJeu m_Wrapper;
        public PlayerActions(@GestionnaireControleJeu wrapper) { m_Wrapper = wrapper; }
        public InputAction @Deplacement => m_Wrapper.m_Player_Deplacement;
        public InputAction @Tir => m_Wrapper.m_Player_Tir;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @Shield => m_Wrapper.m_Player_Shield;
        public InputAction @ShieldSurcharge => m_Wrapper.m_Player_ShieldSurcharge;
        public InputAction @Slow => m_Wrapper.m_Player_Slow;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Deplacement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDeplacement;
                @Deplacement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDeplacement;
                @Deplacement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDeplacement;
                @Tir.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTir;
                @Tir.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTir;
                @Tir.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTir;
                @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Shield.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShield;
                @Shield.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShield;
                @Shield.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShield;
                @ShieldSurcharge.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShieldSurcharge;
                @ShieldSurcharge.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShieldSurcharge;
                @ShieldSurcharge.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShieldSurcharge;
                @Slow.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlow;
                @Slow.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlow;
                @Slow.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlow;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Deplacement.started += instance.OnDeplacement;
                @Deplacement.performed += instance.OnDeplacement;
                @Deplacement.canceled += instance.OnDeplacement;
                @Tir.started += instance.OnTir;
                @Tir.performed += instance.OnTir;
                @Tir.canceled += instance.OnTir;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Shield.started += instance.OnShield;
                @Shield.performed += instance.OnShield;
                @Shield.canceled += instance.OnShield;
                @ShieldSurcharge.started += instance.OnShieldSurcharge;
                @ShieldSurcharge.performed += instance.OnShieldSurcharge;
                @ShieldSurcharge.canceled += instance.OnShieldSurcharge;
                @Slow.started += instance.OnSlow;
                @Slow.performed += instance.OnSlow;
                @Slow.canceled += instance.OnSlow;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // ControlMenu
    private readonly InputActionMap m_ControlMenu;
    private IControlMenuActions m_ControlMenuActionsCallbackInterface;
    private readonly InputAction m_ControlMenu_Enter;
    private readonly InputAction m_ControlMenu_C;
    public struct ControlMenuActions
    {
        private @GestionnaireControleJeu m_Wrapper;
        public ControlMenuActions(@GestionnaireControleJeu wrapper) { m_Wrapper = wrapper; }
        public InputAction @Enter => m_Wrapper.m_ControlMenu_Enter;
        public InputAction @C => m_Wrapper.m_ControlMenu_C;
        public InputActionMap Get() { return m_Wrapper.m_ControlMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlMenuActions set) { return set.Get(); }
        public void SetCallbacks(IControlMenuActions instance)
        {
            if (m_Wrapper.m_ControlMenuActionsCallbackInterface != null)
            {
                @Enter.started -= m_Wrapper.m_ControlMenuActionsCallbackInterface.OnEnter;
                @Enter.performed -= m_Wrapper.m_ControlMenuActionsCallbackInterface.OnEnter;
                @Enter.canceled -= m_Wrapper.m_ControlMenuActionsCallbackInterface.OnEnter;
                @C.started -= m_Wrapper.m_ControlMenuActionsCallbackInterface.OnC;
                @C.performed -= m_Wrapper.m_ControlMenuActionsCallbackInterface.OnC;
                @C.canceled -= m_Wrapper.m_ControlMenuActionsCallbackInterface.OnC;
            }
            m_Wrapper.m_ControlMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Enter.started += instance.OnEnter;
                @Enter.performed += instance.OnEnter;
                @Enter.canceled += instance.OnEnter;
                @C.started += instance.OnC;
                @C.performed += instance.OnC;
                @C.canceled += instance.OnC;
            }
        }
    }
    public ControlMenuActions @ControlMenu => new ControlMenuActions(this);
    public interface IPlayerActions
    {
        void OnDeplacement(InputAction.CallbackContext context);
        void OnTir(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnShield(InputAction.CallbackContext context);
        void OnShieldSurcharge(InputAction.CallbackContext context);
        void OnSlow(InputAction.CallbackContext context);
    }
    public interface IControlMenuActions
    {
        void OnEnter(InputAction.CallbackContext context);
        void OnC(InputAction.CallbackContext context);
    }
}
