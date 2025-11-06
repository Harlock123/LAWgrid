using System.Collections.Generic;
using System.Linq;

namespace LAWgrid;

public partial class LAWgrid
{
    #region Public Utility Methods

    public void SetGridSize(int width, int height)
    {
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
