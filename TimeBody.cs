using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public Transform player;
    public Animator playerAnim;
    public Animator ghostAnim;
    public SpriteRenderer playerSprite;
    public SpriteRenderer ghostSprite;

    float triggerTime = 0;

    List<Vector3> positions;
    List<Quaternion> rotations;
    List<bool> animRun;
    List<bool> animJump;
    List<bool> playerFlip;

    // Start is called before the first frame update
    void Awake()
    {
        positions = new List<Vector3>();
        rotations = new List<Quaternion>();
        animRun = new List<bool>();
        animJump = new List<bool>();
        playerFlip = new List<bool>();

        ghostSprite.enabled = false;

        StartCoroutine(timeCounter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        positions.Add(player.position);
        rotations.Add(player.rotation);
        animRun.Add(playerAnim.GetBool("Run"));
        animJump.Add(playerAnim.GetBool("Jump"));
        playerFlip.Add(playerSprite.flipX);

        if (triggerTime == 2)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
            transform.rotation = rotations[0];
            rotations.RemoveAt(0);
            ghostAnim.SetBool("Run", animRun[0]);
            animRun.RemoveAt(0);
            ghostAnim.SetBool("Jump", animJump[0]);
            animJump.RemoveAt(0);
            ghostSprite.flipX = playerFlip[0];
            playerFlip.RemoveAt(0);
        }
    }

    IEnumerator timeCounter()
    {
        yield return new WaitForSeconds(2f);
        triggerTime = 2;
        ghostSprite.enabled = true;
    }
}
