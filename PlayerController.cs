using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInteract playerInteraction;  // Referensi ke PlayerInteract
    public Animator anim;

    Rigidbody2D rb;

    [Header("Player Movement")]
    public float moveSpd = 5f;

    [Header("Player Input")]
    public float xInput;
    public float yInput;
    public bool interact;

    [Header("Player State")]
    public bool isMoving;
    public bool canInteract;
    public bool onDesk = false;
    public bool onComputer = false;

    [Header("Player Facing")]
    private int facingDir = 1;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Mendapatkan komponen Rigidbody2D
        playerInteraction = GetComponent<PlayerInteract>();  // Mendapatkan referensi ke PlayerInteract
    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayerInput();
        MovePlayer();
        HandleAnimation();
        FlipPlayer();
        playerInteraction.Interact();  // Memanggil interaksi dari PlayerInteract
    }

    // Fungsi untuk menangani input pemain
    void HandlePlayerInput()
    {
        xInput = Input.GetAxis("Horizontal");  // Mendapatkan input horizontal (A/D atau Left/Right)
        yInput = Input.GetAxis("Vertical");  // Mendapatkan input vertikal (W/S atau Up/Down)
        interact = Input.GetKeyDown(KeyCode.E);  // Menangani input interaksi (tombol E)
    }

    // Fungsi untuk menangani pergerakan pemain
    void MovePlayer()
    {
        rb.velocity = new Vector2(xInput * moveSpd, yInput * moveSpd);  // Menggerakkan player dengan kecepatan tertentu
        isMoving = xInput != 0 || yInput != 0;  // Menentukan apakah player sedang bergerak
    }

    // Fungsi untuk menangani animasi pergerakan
    void HandleAnimation()
    {
        anim.SetBool("isMoving", isMoving);  // Mengatur parameter animasi apakah player bergerak atau tidak
    }

    // Fungsi untuk membalik arah player berdasarkan input pergerakan
    void FlipPlayer()
    {
        if (xInput > 0 && !facingRight)  // Jika bergerak ke kanan dan menghadap ke kiri, lakukan flip
        {
            Flip();
        }
        else if (xInput < 0 && facingRight)  // Jika bergerak ke kiri dan menghadap ke kanan, lakukan flip
        {
            Flip();
        }
    }

    // Fungsi untuk melakukan flip player
    void Flip()
    {
        facingDir *= -1;  // Ubah arah menghadap
        facingRight = !facingRight;  // Toggle arah
        transform.Rotate(0f, 180f, 0f);  // Putar player 180 derajat di sumbu Y
    }
}
