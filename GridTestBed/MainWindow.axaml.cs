using System;
using System.Collections.Generic;
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

        cmdTest4.Click += CmdTest4OnClick;
        
        TheGridInTest.TestPopulate();
    }

    private async void CmdTest4OnClick(object? sender, RoutedEventArgs e)
    {
        // Create column headers
        var headers = new List<string>
        {
            "Employee ID",
            "Name",
            "Department",
            "Position",
            "Salary",
            "Active",
            "Hire Date"
        };

        // Create sample data rows
        var data = new List<List<string>>
        {
            new List<string> { "001", "John Smith", "Engineering", "Software Engineer", "$95,000", "TRUE", "2020-01-15" },
            new List<string> { "002", "Jane Doe", "Marketing", "Marketing Manager", "$105,000", "TRUE", "2019-06-20" },
            new List<string> { "003", "Bob Johnson", "Sales", "Sales Representative", "$75,000", "TRUE", "2021-03-10" },
            new List<string> { "004", "Alice Williams", "Engineering", "Senior Developer", "$125,000", "TRUE", "2018-09-05" },
            new List<string> { "005", "Charlie Brown", "HR", "HR Specialist", "$70,000", "FALSE", "2022-11-18" },
            new List<string> { "006", "Diana Prince", "Engineering", "DevOps Engineer", "$110,000", "TRUE", "2020-07-22" },
            new List<string> { "007", "Eve Davis", "Finance", "Financial Analyst", "$85,000", "TRUE", "2021-01-08" },
            new List<string> { "008", "Frank Miller", "Sales", "Sales Director", "$135,000", "TRUE", "2017-04-12" },
            new List<string> { "009", "Grace Lee", "Marketing", "Content Strategist", "$80,000", "FALSE", "2023-02-14" },
            new List<string> { "010", "Henry Taylor", "Engineering", "QA Engineer", "$90,000", "TRUE", "2020-10-30" }
        };

        // Use the async version of ListPopulate
        var result = await TheGridInTest.ListPopulateAsync(headers, data);

        // Log the result to the debug console
        if (result.Success)
        {
            Debug.WriteLine($"ListPopulate succeeded: Loaded {result.RowCount} rows with {headers.Count} columns");
        }
        else
        {
            Debug.WriteLine($"ListPopulate failed: {result.ErrorMessage}");
        }
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
        string ConnectionString = "Server=luisbhds.database.windows.net;Database=LUISBHDS_TEST;User Id=Harlock123;Password=LaserMaster#1";
        
        string Query = "SELECT top 100 * FROM dbo.MEMBERMAIN";

        TheGridInTest.RenderBooleansAsImages = false;
        TheGridInTest.PopulateFromSqlQuerySync(ConnectionString, Query);
        

    }
}