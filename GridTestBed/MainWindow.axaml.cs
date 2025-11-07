using System;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace GridTestBed;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        cmdTest1.Click += CmdTest1OnClick;
        cmdTest2.Click += CmdTest2OnClick;
        cmdTest3.Click += CmdTest3OnClick;
        
        TheGridInTest.TestPopulate();
    }

    private void CmdTest3OnClick(object? sender, RoutedEventArgs e)
    {
        TheGridInTest.TestPopulate();
    }

    private async void CmdTest2OnClick(object? sender, RoutedEventArgs e)
    {
        string ConnectionString = "Server=luisbhds.database.windows.net;Database=LUISBHDS_TEST;User Id={MyUserName};Password={MyPasswordHere}";
        
        string Query = "SELECT top 100 * FROM dbo.MEMBERMAIN";

        var result = await TheGridInTest.PopulateFromSqlQueryAsync(ConnectionString, Query);

        // Log the result to the debug console
        if (result.Success)
        {
            Debug.WriteLine($"Async SQL Query succeeded: Loaded {result.RowCount} rows");
        }
        else
        {
            Debug.WriteLine($"Async SQL Query failed: {result.ErrorMessage}");
        }
    }

    private void CmdTest1OnClick(object? sender, RoutedEventArgs e)
    {
        string ConnectionString = "Server=luisbhds.database.windows.net;Database=LUISBHDS_TEST;User Id={MyUserName};Password={MyPasswordHere}";
        
        string Query = "SELECT top 100 * FROM dbo.MEMBERMAIN";

        TheGridInTest.PopulateFromSqlQuerySync(ConnectionString, Query);
        

    }
}