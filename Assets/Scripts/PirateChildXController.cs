using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateChildXController : MonoBehaviour
{
    public List<Vector3> points; // In the editor, put your rectangle coordinates in here
    private int nextPointIndex = 0;
    private float speed = 0.5f;
    public Animator animator;

    void Start()
    {
        points = new List<Vector3>();
        points.Add(new Vector3(-1.7525f, 2.2215f, 0));
        points.Add(new Vector3(0.72f, 2.2215f, 0));
        points.Add(new Vector3(0.72f, 0.215f, 0));
        points.Add(new Vector3(-1.778f, 0.215f, 0));
    }



    private void Update()
    {
        var reachedNextPoint = transform.position == points[nextPointIndex];

        if (reachedNextPoint)
        {
            nextPointIndex++;
            if (nextPointIndex >= points.Count)
            {
                nextPointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, points[nextPointIndex], speed * Time.deltaTime);

        var heading = points[nextPointIndex] - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;

        if (direction.y == 0 && direction.x > 0)
        {
            animator.Play("PirateChildMoveRight");
        }
        else if (direction.y == 0 && direction.x < 0)
        {
            animator.Play("PirateChildMoveLeft");
        }
        else if (direction.x == 0 && direction.y < 0)
        {
            animator.Play("PirateChildMoveDown");
        }
        else
        {
            animator.Play("PirateChildMoveUp");
        }
    }

    //void FixedUpdate()
    //{
    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        animator.Play("PirateChildMoveRight");
    //    }
    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        animator.Play("PirateChildMoveLeft");
    //    }
    //    if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        animator.Play("PirateChildMoveUp");
    //    }
    //    if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        animator.Play("PirateChildMoveDown");
    //    }
    //}
}
