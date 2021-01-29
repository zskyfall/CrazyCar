using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class RunnerController : MonoBehaviour
{
    private Rigidbody rb;

    public float jumpForce = 600;

    public float gravityModifier = 1.8f;

    public bool isOnGround = true;

    public bool gameOver = false;

    private Animator _animator;
    
    public ParticleSystem explosionParticle;

    public ParticleSystem dirtParticle;

    private AudioSource playAudio;
    
    public AudioClip jumpSound;
    
    public AudioClip crashSound;

    public AudioClip crashBombSound;

    public Text txtGuide;
    
    private int point = 0;
    
    private Vector3 baseGravity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        baseGravity = Physics.gravity;
        Physics.gravity *= gravityModifier;
        //Debug.Log("Gravity:" + Physics.gravity);
        playAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Inscrease Point
        if (gameOver == false)
        {
            point++;
        }

        //Controller for PC
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            _animator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playAudio.PlayOneShot(jumpSound,1.0f);
            
            //Hide the guiding text
            if (txtGuide.IsActive())
            {
                txtGuide.gameObject.SetActive(false);
            }
        }
        //Controller For Mobile Devices
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            _animator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playAudio.PlayOneShot(jumpSound,1.0f);
            
            //Hide the guiding text
            if (txtGuide.IsActive())
            {
                txtGuide.gameObject.SetActive(false);
            }
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (other.gameObject.CompareTag("Obstacel"))
        {
            gameOver = true;
            //Update High Score
            UpdateHighScore(point);
            Debug.Log("Game Over");
            Physics.gravity = baseGravity;
            _animator.SetBool("Death_b", true);
            _animator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            Destroy(other.gameObject);
            gameOver = true;
            //Update High Score
            UpdateHighScore(point);
            Physics.gravity = baseGravity;
            _animator.SetBool("Death_b", true);
            _animator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playAudio.PlayOneShot(crashBombSound, 1.0f);
        }
    }

    private void UpdateHighScore(int point)
    {
        Debug.Log("Score update: " + point);
        int[] scores = PlayerPrefsX.GetIntArray("scores");
        var tempList = scores.ToList();
        tempList.Add(point);
        scores = tempList.ToArray();
        
        Array.Sort(scores);

        PlayerPrefsX.SetIntArray("scores", scores);
        
        // for (int i = 0; i < scores.Length; i++)
        // {
        //     Debug.Log("rank: " + i + " : " + scores[i]);
        // }
    }

    private int[] SortIntArray(int[] arr)
    {
        if (arr.Length > 0)
        {
            int temp;
            for (int j = 0; j <= arr.Length - 2; j++) {
                for (int i = 0; i <= arr.Length - 2; i++) {
                    if (arr[i] > arr[i + 1]) {
                        temp= arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
        }

        return arr;
    }
}
