# LAWgrid

A custom data grid control built for Avalonia UI - a cross-platform .NET UI framework.

## Overview

LAWgrid is a user control that displays tabular data in a grid format with extensive customization options and direct SQL Server integration capabilities.

## Features

### Data Population
- **SQL Server Integration**: Direct population from SQL Server queries via `PopulateFromSqlQuerySync()` method
- **Test Data Support**: Built-in test data population for development and testing

### Visual Customization
- Configurable colors for backgrounds, cells, headers, and highlights
- Customizable fonts and typefaces (title, header, and cell content)
- Adjustable font sizes for different grid sections
- Configurable cell padding (width and height)
- Cell outline customization

### Interactive Features
- **Mouse Tracking**: Real-time mouse position tracking with optional crosshairs
- **Cell Highlighting**: Visual feedback when hovering over cells
- **Cell Selection**: Support for selecting individual items
- **Double-Click Detection**: Built-in double-click timer for handling user interactions
- **Context Menu**: Right-click menu with font size adjustment options
- **Scrolling**: Both horizontal and vertical scrollbars with configurable scroll multiplier

### Layout & Rendering
- **Auto-sizing**: Cells can automatically resize to fit their contents
- **Dynamic Dimensions**: Configurable grid width and height
- **Viewport Management**: Grid shift support for X and Y coordinates
- **Clipping**: Content properly clipped to grid boundaries
- **Suspend Rendering**: Option to temporarily suspend rendering for batch updates

### Built-in Icons
- Checkmark icon
- Red X icon
- Folder icon
- File icon

## Project Structure

```
LAWgrid/
├── LAWgrid/              # Main grid control library
│   ├── LAWgrid.axaml     # XAML layout definition
│   ├── LAWgrid.axaml.cs  # Control implementation
│   └── LAWgrid.csproj    # Project file
├── GridTestBed/          # Test application
│   ├── MainWindow.axaml
│   ├── MainWindow.axaml.cs
│   ├── Program.cs
│   └── GridTestBed.csproj
└── LAWgrid.sln           # Solution file
```

## Dependencies

- **Avalonia** (v11.2.2): Cross-platform UI framework
- **Avalonia.Desktop** (v11.2.2): Desktop-specific Avalonia components
- **Microsoft.Data.SqlClient** (v6.0.1): SQL Server data access
- **Target Framework**: .NET 8.0

## Usage Example

```csharp
// Basic SQL query population
string connectionString = "Server=myserver.database.windows.net;Database=MyDB;User Id=username;Password=password";
string query = "SELECT * FROM MyTable";

TheGridInTest.PopulateFromSqlQuerySync(connectionString, query);
```

```csharp
// Populate with test data
TheGridInTest.TestPopulate();
```

## Configuration Options

### Title & Header
- `GridTitle`: Title text displayed at the top
- `GridTitleFontSize`: Font size for the title (default: 20)
- `GridTitleHeight`: Height of the title area (default: 10)
- `GridHeaderFontSize`: Font size for column headers (default: 14)

### Cell Appearance
- `GridFontSize`: Font size for cell content (default: 12)
- `CellPaddingWidth`: Horizontal padding (default: 10)
- `CellPaddingHeight`: Vertical padding (default: 10)
- `AutosizeCellsToContents`: Enable/disable auto-sizing (default: true)

### Colors & Brushes
- `GridBackground`: Background color (default: Cornsilk)
- `GridCellBrush`: Cell background color (default: Wheat)
- `GridCellOutline`: Cell border color (default: Black)
- `GridCellContentBrush`: Cell text color (default: Black)
- `GridCellHighlightBrush`: Highlighted cell color (default: LightBlue)
- `GridSelectedItemBrush`: Selected item color (default: AliceBlue)
- `GridTitleBackground`: Title area background (default: Blue)
- `GridHeaderBackground`: Header area background (default: Cyan)

### Interaction
- `ShowCrossHairs`: Enable/disable crosshair cursor (default: true)
- `CrossHairBrush`: Crosshair color (default: Red)
- `ScrollMultiplier`: Scroll speed multiplier (default: 3)

## Context Menu Options

Right-click on the grid to access:
- **Fonts Larger**: Increase font sizes
- **Fonts Smaller**: Decrease font sizes

## Development

The GridTestBed project serves as a development and testing environment for the LAWgrid control. It includes three test buttons for different functionality testing scenarios.

## Platform Support

As an Avalonia-based control, LAWgrid supports:
- Windows
- Linux
- macOS

## License

[Add your license information here]

## Author

[Add author information here]
