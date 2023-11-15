//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/PlayerControls.inputactions
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

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""b84b623b-b8ba-4bb2-8610-8018465ca16f"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e71e670a-86fe-4092-8488-a118551ac86e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""044bf3f4-4b0b-4bdb-9a3a-7d8818be2e87"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""ea1428bf-8096-4fc9-97bd-b854c956ab8a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Resume"",
                    ""type"": ""Button"",
                    ""id"": ""1dbe186b-6a94-49b4-9b41-98e44c7ba1ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""0e23b571-92d0-4822-96a9-8c4436fdb8a0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""306c69ba-2777-48cc-9b91-0000206a1d6c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b988aa04-663c-4bc7-8f30-aeaa3a61979e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""54630fea-cc9e-4861-861a-f2325db0070c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6000925a-0701-4c73-b5ca-6351f3a96811"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Control"",
                    ""id"": ""9dc45b42-f9e5-41f0-bfcf-fa5cdbe5b3f5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""13af5ea6-7b9c-411e-b899-e157c916992d"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""deaa82be-02ed-42ec-a44b-18e7dbfaa13b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ce132b08-18a0-442f-aa2e-cb71a4d1bde1"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""aa1fd071-edaa-4663-b8bf-951240a25957"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b7dc2484-1427-47d8-905b-2801fac43b4d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb0ec0a0-b532-40c4-b1e8-0d93787c1b74"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0819ef63-b2ca-482d-8d11-c0f1209bdd37"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77f8e3d0-adf5-41d4-b143-311c2ffc8c03"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45c74007-c2a5-42fe-be1b-5b86ef59c5d6"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Resume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1166a3f5-df1f-46b8-bbbe-3f605d5ff3b6"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Resume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Combat"",
            ""id"": ""a1a13fc2-e88f-4134-bb42-718d9d38bf09"",
            ""actions"": [
                {
                    ""name"": ""SocoAlto"",
                    ""type"": ""Button"",
                    ""id"": ""e4f7f513-964c-4e1b-8a24-284bad0e6d7b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SocoBaixo"",
                    ""type"": ""Button"",
                    ""id"": ""4f9752e0-6e67-4c77-9b96-137dd9950603"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChuteAlto"",
                    ""type"": ""Button"",
                    ""id"": ""29b3ea00-5c87-423e-9c06-ab764571a338"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChuteBaixo"",
                    ""type"": ""Button"",
                    ""id"": ""f479c802-b641-42d2-ab5c-8c4ebdadfe5c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Bloqueio"",
                    ""type"": ""Button"",
                    ""id"": ""d50fbad3-977d-4d0c-8d4a-514d97bf8aa4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Agarrar"",
                    ""type"": ""Button"",
                    ""id"": ""426d5757-e5cc-486c-804b-f7d1e0bafc0f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cima"",
                    ""type"": ""Button"",
                    ""id"": ""908b123c-3344-4d6c-a3e1-786a93107506"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Baixo"",
                    ""type"": ""Button"",
                    ""id"": ""b033b246-4d1d-4b89-8b6e-e04907efbea4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Esquerda"",
                    ""type"": ""Button"",
                    ""id"": ""73e6be53-e00f-406f-8fb4-d005ca0cff40"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Direita"",
                    ""type"": ""Button"",
                    ""id"": ""853da7a3-f123-413d-b8c9-0daca284b09e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""95e08734-0497-4e06-bfdc-9c52f71e668b"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SocoAlto"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75f6340a-3923-4042-aa42-317575ed8a80"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SocoAlto"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71c5d53d-cc5b-4646-b58c-02503a31e322"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SocoBaixo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af146a59-ff67-49d3-baff-143c1f14c68e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SocoBaixo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32f9ddc4-3428-4b0a-8bb9-c79601192f06"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChuteAlto"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41d598fa-8805-421b-8490-f3d48bbf0ede"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChuteAlto"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5b1f3a8-2b0b-4b10-8b0f-ae40eeeb5cc8"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChuteBaixo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e22024d-adaa-48fc-926e-ca3185769f42"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChuteBaixo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a5ac605-c154-4128-8fb4-08d76e6f838a"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bloqueio"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed1abcaf-a722-42e9-bfca-120f191026bc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bloqueio"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88e7cc00-ccb6-46f6-bf8d-f344f1f86481"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direita"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fa204e2-6416-4976-9221-30d731bc5b8c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direita"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b79fc692-3312-4444-9a5d-a815f8d863cf"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cima"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4d5920a-df50-47c4-878b-139d0ab06e2a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cima"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2533f950-8935-462e-b994-d4a4d647993f"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Baixo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a01782a-3d44-4b84-bd8a-6d5b4f2286e7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Baixo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c95f2380-dbd4-4d7d-ae3b-d42bc8d43f2d"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Esquerda"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d3a806b-5f30-4491-aff5-dc96a79a64a1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Esquerda"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12d1af1c-14c0-476d-815a-a2d47576c74c"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Agarrar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86712caa-379d-45b8-b664-271b165a7733"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Agarrar"",
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
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        m_Player_Resume = m_Player.FindAction("Resume", throwIfNotFound: true);
        // Combat
        m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
        m_Combat_SocoAlto = m_Combat.FindAction("SocoAlto", throwIfNotFound: true);
        m_Combat_SocoBaixo = m_Combat.FindAction("SocoBaixo", throwIfNotFound: true);
        m_Combat_ChuteAlto = m_Combat.FindAction("ChuteAlto", throwIfNotFound: true);
        m_Combat_ChuteBaixo = m_Combat.FindAction("ChuteBaixo", throwIfNotFound: true);
        m_Combat_Bloqueio = m_Combat.FindAction("Bloqueio", throwIfNotFound: true);
        m_Combat_Agarrar = m_Combat.FindAction("Agarrar", throwIfNotFound: true);
        m_Combat_Cima = m_Combat.FindAction("Cima", throwIfNotFound: true);
        m_Combat_Baixo = m_Combat.FindAction("Baixo", throwIfNotFound: true);
        m_Combat_Esquerda = m_Combat.FindAction("Esquerda", throwIfNotFound: true);
        m_Combat_Direita = m_Combat.FindAction("Direita", throwIfNotFound: true);
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
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Pause;
    private readonly InputAction m_Player_Resume;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputAction @Resume => m_Wrapper.m_Player_Resume;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
            @Resume.started += instance.OnResume;
            @Resume.performed += instance.OnResume;
            @Resume.canceled += instance.OnResume;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
            @Resume.started -= instance.OnResume;
            @Resume.performed -= instance.OnResume;
            @Resume.canceled -= instance.OnResume;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Combat
    private readonly InputActionMap m_Combat;
    private List<ICombatActions> m_CombatActionsCallbackInterfaces = new List<ICombatActions>();
    private readonly InputAction m_Combat_SocoAlto;
    private readonly InputAction m_Combat_SocoBaixo;
    private readonly InputAction m_Combat_ChuteAlto;
    private readonly InputAction m_Combat_ChuteBaixo;
    private readonly InputAction m_Combat_Bloqueio;
    private readonly InputAction m_Combat_Agarrar;
    private readonly InputAction m_Combat_Cima;
    private readonly InputAction m_Combat_Baixo;
    private readonly InputAction m_Combat_Esquerda;
    private readonly InputAction m_Combat_Direita;
    public struct CombatActions
    {
        private @PlayerControls m_Wrapper;
        public CombatActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @SocoAlto => m_Wrapper.m_Combat_SocoAlto;
        public InputAction @SocoBaixo => m_Wrapper.m_Combat_SocoBaixo;
        public InputAction @ChuteAlto => m_Wrapper.m_Combat_ChuteAlto;
        public InputAction @ChuteBaixo => m_Wrapper.m_Combat_ChuteBaixo;
        public InputAction @Bloqueio => m_Wrapper.m_Combat_Bloqueio;
        public InputAction @Agarrar => m_Wrapper.m_Combat_Agarrar;
        public InputAction @Cima => m_Wrapper.m_Combat_Cima;
        public InputAction @Baixo => m_Wrapper.m_Combat_Baixo;
        public InputAction @Esquerda => m_Wrapper.m_Combat_Esquerda;
        public InputAction @Direita => m_Wrapper.m_Combat_Direita;
        public InputActionMap Get() { return m_Wrapper.m_Combat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
        public void AddCallbacks(ICombatActions instance)
        {
            if (instance == null || m_Wrapper.m_CombatActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CombatActionsCallbackInterfaces.Add(instance);
            @SocoAlto.started += instance.OnSocoAlto;
            @SocoAlto.performed += instance.OnSocoAlto;
            @SocoAlto.canceled += instance.OnSocoAlto;
            @SocoBaixo.started += instance.OnSocoBaixo;
            @SocoBaixo.performed += instance.OnSocoBaixo;
            @SocoBaixo.canceled += instance.OnSocoBaixo;
            @ChuteAlto.started += instance.OnChuteAlto;
            @ChuteAlto.performed += instance.OnChuteAlto;
            @ChuteAlto.canceled += instance.OnChuteAlto;
            @ChuteBaixo.started += instance.OnChuteBaixo;
            @ChuteBaixo.performed += instance.OnChuteBaixo;
            @ChuteBaixo.canceled += instance.OnChuteBaixo;
            @Bloqueio.started += instance.OnBloqueio;
            @Bloqueio.performed += instance.OnBloqueio;
            @Bloqueio.canceled += instance.OnBloqueio;
            @Agarrar.started += instance.OnAgarrar;
            @Agarrar.performed += instance.OnAgarrar;
            @Agarrar.canceled += instance.OnAgarrar;
            @Cima.started += instance.OnCima;
            @Cima.performed += instance.OnCima;
            @Cima.canceled += instance.OnCima;
            @Baixo.started += instance.OnBaixo;
            @Baixo.performed += instance.OnBaixo;
            @Baixo.canceled += instance.OnBaixo;
            @Esquerda.started += instance.OnEsquerda;
            @Esquerda.performed += instance.OnEsquerda;
            @Esquerda.canceled += instance.OnEsquerda;
            @Direita.started += instance.OnDireita;
            @Direita.performed += instance.OnDireita;
            @Direita.canceled += instance.OnDireita;
        }

        private void UnregisterCallbacks(ICombatActions instance)
        {
            @SocoAlto.started -= instance.OnSocoAlto;
            @SocoAlto.performed -= instance.OnSocoAlto;
            @SocoAlto.canceled -= instance.OnSocoAlto;
            @SocoBaixo.started -= instance.OnSocoBaixo;
            @SocoBaixo.performed -= instance.OnSocoBaixo;
            @SocoBaixo.canceled -= instance.OnSocoBaixo;
            @ChuteAlto.started -= instance.OnChuteAlto;
            @ChuteAlto.performed -= instance.OnChuteAlto;
            @ChuteAlto.canceled -= instance.OnChuteAlto;
            @ChuteBaixo.started -= instance.OnChuteBaixo;
            @ChuteBaixo.performed -= instance.OnChuteBaixo;
            @ChuteBaixo.canceled -= instance.OnChuteBaixo;
            @Bloqueio.started -= instance.OnBloqueio;
            @Bloqueio.performed -= instance.OnBloqueio;
            @Bloqueio.canceled -= instance.OnBloqueio;
            @Agarrar.started -= instance.OnAgarrar;
            @Agarrar.performed -= instance.OnAgarrar;
            @Agarrar.canceled -= instance.OnAgarrar;
            @Cima.started -= instance.OnCima;
            @Cima.performed -= instance.OnCima;
            @Cima.canceled -= instance.OnCima;
            @Baixo.started -= instance.OnBaixo;
            @Baixo.performed -= instance.OnBaixo;
            @Baixo.canceled -= instance.OnBaixo;
            @Esquerda.started -= instance.OnEsquerda;
            @Esquerda.performed -= instance.OnEsquerda;
            @Esquerda.canceled -= instance.OnEsquerda;
            @Direita.started -= instance.OnDireita;
            @Direita.performed -= instance.OnDireita;
            @Direita.canceled -= instance.OnDireita;
        }

        public void RemoveCallbacks(ICombatActions instance)
        {
            if (m_Wrapper.m_CombatActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICombatActions instance)
        {
            foreach (var item in m_Wrapper.m_CombatActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CombatActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CombatActions @Combat => new CombatActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnResume(InputAction.CallbackContext context);
    }
    public interface ICombatActions
    {
        void OnSocoAlto(InputAction.CallbackContext context);
        void OnSocoBaixo(InputAction.CallbackContext context);
        void OnChuteAlto(InputAction.CallbackContext context);
        void OnChuteBaixo(InputAction.CallbackContext context);
        void OnBloqueio(InputAction.CallbackContext context);
        void OnAgarrar(InputAction.CallbackContext context);
        void OnCima(InputAction.CallbackContext context);
        void OnBaixo(InputAction.CallbackContext context);
        void OnEsquerda(InputAction.CallbackContext context);
        void OnDireita(InputAction.CallbackContext context);
    }
}
