using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class movement1 : MonoBehaviour
{
    bool f;
    private float speed = 20f;
    private Rigidbody rb;
    private PlayerInput input;
    public GameObject prefab;
    string option;
    [SerializeField] Animator animator;

    public enum control
    {
        keybord,
        Control
    }
    public control SelectedConrol;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInput>();
        switch(SelectedConrol)
        {
            case control.keybord:
                option = "Move";
                break;
                case control.Control:
                option = "Control";
                break;
        }
    }
    
        
    // Update is called once per frame
    void Update()
    {
       

        Vector3 moveimput = input.actions[option].ReadValue<Vector3>();
        rb.AddForce(moveimput*speed,ForceMode.Force);
        
        animator.SetFloat("horizontalWalking", moveimput.z);
        animator.SetFloat("verticalMovement", moveimput.x);

        if (transform.position.y < -1f)
        {
            SceneManager.LoadScene("Gameover");
        }
      
     
        
       
       
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            prefab.SetActive(true);
            rb.drag = 1.45f;
            animator.SetBool("f", true);
        }
   
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TG"))
        {
            prefab.SetActive(false);
            rb.drag = 0f;
            animator.SetBool("f", false);
        }
        if (collision.gameObject.CompareTag("win"))
        {
            SceneManager.LoadScene("Victory");
        }
    }

}
