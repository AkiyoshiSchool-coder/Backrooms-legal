using JetBrains.Annotations;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;

public class Push : MonoBehaviour
{
    [SerializeField] private InputActionReference pushingAction; // Tecla E
    [SerializeField] private Texture hand; //Cursor
    [SerializeField] private Texture normal; //Cursor
    private GameObject objpuxavel; //Caixa que o Player interage
    private bool perto; //Se o Player está perto
    public bool umavez = false; //Para ele nao pegar a caixa mais de uma vez
    [SerializeField] private Color colorNew; //Cor da mao
    [SerializeField] private Vector3 maoTamanho;
     [SerializeField] private Vector3 normalTamanho; //Tamanho do cursor original
    private Rigidbody rb; //Rigidbody da Caixa
    private bool pegavel; //Ve se ele tem o Script Pegavel 
    [SerializeField] private FirstPersonMovement firstPersonMovement; //Movimento do Player
    [SerializeField] private Jump jump; //Pulo do Player
    [SerializeField] private GameObject box; //Define a posicao a onde a caixa vai ficar quando pega
    [SerializeField] private StudioEventEmitter caixaSound; //Fmod

    private void OnEnable()
    {
        pushingAction.action.performed += PushingObject;
    }
    private void OnDisable()
    {
        pushingAction.action.performed -= PushingObject;
    }

    void OnTriggerEnter(Collider other) //Quando o Player entra em contato com qualquer objeto
    {
        if(umavez == false) //Para ele nao pegar a caixa mais de uma vez
        {
            if(other.tag == "Box") //Ve se e uma caixa 
            {
                UIManager.instance.ChangeImage(hand); //Cursor
                UIManager.instance.ChangeScale(maoTamanho); //Cursor
                objpuxavel = other.gameObject;  //Caixa que o Player interage
                rb = objpuxavel.GetComponent<Rigidbody>(); //Rigidbody da Caixa
                pegavel = objpuxavel.GetComponent<Pegavel>();
                rb.constraints = RigidbodyConstraints.FreezeAll; //Congela a gravidade
                perto = true; //O Player está perto
            }  
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Box") //Ve se e uma caixa
        {
            UIManager.instance.ChangeImage(normal); //Cursor
            UIManager.instance.ChangeScale(normalTamanho); //Cursor
            UIManager.instance.ChangeColor(Color.black); //Cursor

            if (pegavel == false) //Ve se ele tem o Script Pegavel caso nao ter ele e arrastavel
            {

                if (objpuxavel != null) //Se ele existe nao vai mais
                {
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                    objpuxavel = null;
                    perto = false;
                    rb = null;
                }
            }
            else //Tem Pegavel vai a um lugar diferente
            {   
                if (umavez == true)
                {
                    StopCarrying();
                }
            } 
        }
    }

    public void PushingObject(InputAction.CallbackContext context) //Caixa ativa
    {
        if (umavez == false)
        {
            if (perto == true)
            {
                if (objpuxavel != null)
                {
                    UIManager.instance.ChangeImage(hand);
                    UIManager.instance.ChangeScale(maoTamanho);
                    UIManager.instance.ChangeColor(colorNew);
                    caixaSound.Play();

                    rb.constraints &= ~RigidbodyConstraints.FreezePosition;
    
                    if(pegavel == true)
                    {
                        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
                        objpuxavel.transform.position = box.transform.position;
                        firstPersonMovement.PushingObject(rb);
                        jump.PushingObject(rb);
                        umavez = true;
                    }
                }
            }
        }
        else
        {
            StopCarrying();
        }
    }
    public void StopCarrying()
    {
        firstPersonMovement.StopPushing();
        jump.StopPushing();
        rb.constraints &= ~RigidbodyConstraints.FreezePosition;
    
        if (objpuxavel != null)
        {
            objpuxavel = null;
        }
        perto = false;
        umavez = false;
        rb = null;
    }
}