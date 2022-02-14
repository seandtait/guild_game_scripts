using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour 
{
    #region Mechanics
    public bool dragging = false;
    public Vector3 clickOffset;
    public GameObject shadow;
    public GameObject sprite;

    SpriteAnimation sa;
    Camera cam;

    bool allowDrag;

    public GameObject AbilityScoreCanvas;
    #endregion

    #region Stats
    public Jobs job = Jobs.NONE;

    #endregion

    private void OnMouseEnter()
    {
        if(dragging) { return; }
        AbilityScoreCanvas.GetComponent<AbilityScoreCanvas>().Refresh();
        AbilityScoreCanvas.SetActive(true);
    }

    private void OnMouseExit()
    {
        AbilityScoreCanvas.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!allowDrag) { return; }

        GameController.instance.DragObject = gameObject;

        dragging = true;

        Vector3 clickPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        clickOffset = transform.position - clickPoint;

        shadow.transform.localScale = new Vector3(0.85f, 0.85f, 1);
        shadow.GetComponent<SpriteRenderer>().sortingOrder = 1;
        sprite.transform.localPosition += new Vector3(0, 0.5f, 0);
        sprite.GetComponent<SpriteRenderer>().sortingOrder = 1;
        sa.Animate(false);
    }

    private void OnMouseUp()
    {
        if (!allowDrag) { return; }
        GameController.instance.DragObject = null;

        dragging = false;

        shadow.transform.localScale = new Vector3(1f, 1f, 1);
        shadow.GetComponent<SpriteRenderer>().sortingOrder = 0;
        sprite.transform.localPosition -= new Vector3(0, 0.5f, 0);
        sprite.GetComponent<SpriteRenderer>().sortingOrder = 0;

        sa.Animate(true);

        // Get the current Drop Panel, for sorting heroes later.
        DropPanel previousPanel = GetComponentInParent<DropPanel>();



        if (GameController.instance.ActiveDropPanel &&
            GameController.instance.ActiveDropPanel != previousPanel.gameObject &&
            GameController.instance.ActiveDropPanel.GetComponent<DropPanel>().HasSpace(this))
        {
            // Add the hero to the new panel
            GameController.instance.ActiveDropPanel.GetComponent<DropPanel>().DropHero(gameObject);
            // Rearrange the previous panel
            previousPanel.Rearrange();
            // Reset game objects
        } else
        {
            // No panel is active, return to previous panel
            transform.localPosition = new Vector3(0, 0, -5);
        }

        GameController.instance.ActiveDropPanel = null;
        GameController.instance.DragObject = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        sa = GetComponentInChildren<SpriteAnimation>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            transform.position = pos + clickOffset;
            
        }
    }

    private void FixedUpdate()
    {
        allowDrag = GameController.instance.currentState.GetType() == typeof(AssignmentGameState);
    }

    



}
