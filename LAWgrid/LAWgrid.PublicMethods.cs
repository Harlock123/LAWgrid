using System.Collections.Generic;
using System.Linq;

namespace LAWgrid;

public partial class LAWgrid
{
    #region Public Utility Methods

    public void SetGridSize(int width, int height)
    {
        // Note: When using Stretch alignment in XAML, Canvas size is determined by container
        // This method allows programmatic sizing but may be overridden by layout system
        TheCanvas.Width = width;
        TheCanvas.Height = height;
        Width = width + 12;
        Height = height + 12;
        ReRender();
    }

    public string GetFirstSelectedFolder()
    {
        string result = "";

        foreach(AFileEntry item in SelectedItems)
        {
            //var item = i.ItemUnderMouse as AFileEntry;

            if ( item.Typ)
            {
                result = item.Name;
                break;
            }
        }

        return result;
    }

    public List<AFileEntry> GetListOfSelectedFiles()
    {
        List<AFileEntry> result = new List<AFileEntry>();

        foreach (AFileEntry item in SelectedItems)
        {
            //var item = i.ItemUnderMouse as AFileEntry;

            if (!item.Typ)
            {
                result.Add(item);
            }
        }

        return result;
    }

    public void SelectAllFilesOnly()
    {
        SelectedItems.Clear();

        foreach (AFileEntry item in Items)
        {
            if (!item.Typ)
            {
                SelectedItems.Add(item);
            }
        }

        ReRender();
    }

    public void SelectAllFoldersOnly()
    {
        SelectedItems.Clear();

        foreach (AFileEntry item in Items)
        {
            if (item.Typ)
            {
                SelectedItems.Add(item);
            }
        }

        ReRender();
    }

    #endregion
}
