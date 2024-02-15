using UnityEngine;

public class PageController : MonoBehaviour
{
    public GameObject[] pages;
    private int currentPageIndex = 0;

    void Update()
    {
        // Check for arrow key input
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Move to the previous page
            ShowPage(currentPageIndex - 1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Check if we are on the last page
            if (currentPageIndex == pages.Length - 1)
            {
                // Disable the canvas or perform any other action
                DisableCanvas();
            }
            else
            {
                // Move to the next page
                ShowPage(currentPageIndex + 1);
            }
        }
    }

    void ShowPage(int pageIndex)
    {
        // Ensure the index is within the valid range
        pageIndex = Mathf.Clamp(pageIndex, 0, pages.Length - 1);

        // Hide the current page
        if (currentPageIndex < pages.Length)
        {
            pages[currentPageIndex].SetActive(false);
        }

        // Show the new page
        pages[pageIndex].SetActive(true);

        // Update the current page index
        currentPageIndex = pageIndex;
    }

    void DisableCanvas()
    {
        // Perform any action needed to disable the canvas
        // For example, you can disable the GameObject that holds the canvas
        gameObject.SetActive(false);
    }
}
