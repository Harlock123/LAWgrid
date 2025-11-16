# LAWgrid

A custom data grid control built for Avalonia UI - a cross-platform .NET UI framework.

## Overview

LAWgrid is a user control that displays tabular data in a grid format with extensive customization options and direct SQL Server integration capabilities.

## Features

### Data Population
- **SQL Server Integration**: Direct population from SQL Server queries via `PopulateFromSqlQuerySync()` method
- **DataTable Support**: Populate from .NET DataTable objects via `PopulateFromDataTable()` method
- **Test Data Support**: Built-in test data population for development and testing

### Visual Customization
- Configurable colors for backgrounds, cells, headers, and highlights
- **GreenBar Mode**: Alternating row colors for improved readability
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

### Image Export
- **PNG Export**: Save grid visual to PNG format
- **JPEG Export**: Save grid visual to JPEG with quality control
- **BMP Export**: Save grid visual to BMP format
- **Desktop Quick Save**: One-click save to Desktop
- **Clipboard Support**: Copy grid visual to clipboard (cross-platform)

## Project Structure

```
LAWgrid/
├── LAWgrid/                        # Main grid control library
│   ├── LAWgrid.axaml               # XAML layout definition
│   ├── LAWgrid.axaml.cs            # Main partial class (constructor, variables, events)
│   ├── LAWgrid.Properties.cs       # Partial class - Public properties
│   ├── LAWgrid.Rendering.cs        # Partial class - Rendering methods
│   ├── LAWgrid.SqlMethods.cs       # Partial class - SQL population methods
│   ├── LAWgrid.DataPopulation.cs   # Partial class - Data population methods
│   ├── LAWgrid.EventHandlers.cs    # Partial class - Event handlers
│   ├── LAWgrid.PublicMethods.cs    # Partial class - Public utility methods
│   ├── LAWgrid.PrivateMethods.cs   # Partial class - Private helper methods
│   ├── LAWgrid.HelperClasses.cs    # Helper classes and data models
│   └── LAWgrid.csproj              # Project file
├── GridTestBed/                    # Test application
│   ├── App.axaml
│   ├── App.axaml.cs
│   ├── MainWindow.axaml
│   ├── MainWindow.axaml.cs
│   ├── Program.cs
│   └── GridTestBed.csproj
└── LAWgrid.sln                     # Solution file
```

### LAWgrid Partial Class Organization

The LAWgrid control is organized into multiple partial class files for better maintainability and code organization:

- **LAWgrid.axaml.cs** (159 lines) - Core class with constructor, private variables, and event declarations
- **LAWgrid.Properties.cs** (438 lines) - All public properties with DefaultValue attributes
- **LAWgrid.Rendering.cs** (454 lines) - Main rendering logic and ReRender() method
- **LAWgrid.SqlMethods.cs** (262 lines) - SQL Server query population methods
- **LAWgrid.DataPopulation.cs** (150 lines) - Array and test data population methods
- **LAWgrid.EventHandlers.cs** (398 lines) - Mouse, pointer, scroll, and context menu handlers
- **LAWgrid.PublicMethods.cs** (85 lines) - Public utility methods for grid manipulation
- **LAWgrid.PrivateMethods.cs** (127 lines) - Private helper methods
- **LAWgrid.HelperClasses.cs** (914 lines) - Supporting classes and data models

## Dependencies

- **Avalonia** (v11.2.2): Cross-platform UI framework
- **Avalonia.Desktop** (v11.2.2): Desktop-specific Avalonia components
- **Microsoft.Data.SqlClient** (v6.0.1): SQL Server data access
- **SkiaSharp** (v2.88.9): Image encoding for JPEG/BMP export
- **Target Framework**: .NET 9.0

## Usage Examples

### Data Population

```csharp
// Basic SQL query population
string connectionString = "Server=myserver.database.windows.net;Database=MyDB;User Id=username;Password=password";
string query = "SELECT * FROM MyTable";
TheGridInTest.PopulateFromSqlQuerySync(connectionString, query);
```

```csharp
// Populate from DataTable
DataTable dt = new DataTable();
dt.Columns.Add("ID", typeof(int));
dt.Columns.Add("Name", typeof(string));
dt.Rows.Add(1, "John Doe");
dt.Rows.Add(2, "Jane Smith");
TheGridInTest.PopulateFromDataTable(dt);
```

```csharp
// Populate with test data
TheGridInTest.TestPopulate();
```

### Visual Customization

```csharp
// Enable GreenBar mode with alternating row colors
TheGridInTest.GreenBarMode = true;
TheGridInTest.GreenBarColor1 = Brushes.White;
TheGridInTest.GreenBarColor2 = Brushes.PaleGreen;

// Or toggle it programmatically
TheGridInTest.ToggleGreenBarMode();
```

### Image Export

```csharp
// Save to Desktop (quick and easy)
string? filePath = TheGridInTest.SaveGridToDesktop();

// Save to specific location as PNG
TheGridInTest.SaveGridAsPng("/path/to/output.png");

// Save as JPEG with quality control (0-100)
TheGridInTest.SaveGridAsJpg("/path/to/output.jpg", quality: 90);

// Save as BMP
TheGridInTest.SaveGridAsBmp("/path/to/output.bmp");

// Copy to clipboard (cross-platform)
await TheGridInTest.CopyGridToClipboardAsync();
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
- `GreenBarMode`: Enable alternating row colors (default: false)
- `GreenBarColor1`: First alternating row color (default: White)
- `GreenBarColor2`: Second alternating row color (default: PaleGreen)

### Interaction
- `ShowCrossHairs`: Enable/disable crosshair cursor (default: true)
- `CrossHairBrush`: Crosshair color (default: Red)
- `ScrollMultiplier`: Scroll speed multiplier (default: 3)

## Context Menu Options

Right-click on the grid to access:
- **Fonts Larger**: Increase font sizes
- **Fonts Smaller**: Decrease font sizes

- **Alt MouseWheel will also increase and decrease displayed font sizes

## API Reference

### Data Population Methods

#### `PopulateFromDataTable(DataTable dataTable)`
Populates the grid from a .NET DataTable object.
- **Parameters**:
  - `dataTable`: The DataTable containing the data to display
- **Returns**: `bool` - True if successful, false otherwise
- **Example**: See Usage Examples section above

### Visual Customization Methods

#### `ToggleGreenBarMode()`
Toggles the GreenBarMode on or off (alternating row colors).
- **Returns**: void
- **Example**: `TheGridInTest.ToggleGreenBarMode();`

### Image Export Methods

#### `SaveGridToDesktop()`
Saves the grid visual as a PNG file to the user's Desktop.
- **Returns**: `string?` - The full path to the saved file, or null if failed
- **Example**: `string? path = TheGridInTest.SaveGridToDesktop();`

#### `SaveGridAsPng(string filePath)`
Saves the grid visual as a PNG file to a specific location.
- **Parameters**:
  - `filePath`: The file path where to save the PNG
- **Returns**: `bool` - True if successful, false otherwise
- **Example**: `TheGridInTest.SaveGridAsPng("/path/to/output.png");`

#### `SaveGridAsJpg(string filePath, int quality = 90)`
Saves the grid visual as a JPEG file with configurable quality.
- **Parameters**:
  - `filePath`: The file path where to save the JPEG
  - `quality`: JPEG quality (0-100, default: 90)
- **Returns**: `bool` - True if successful, false otherwise
- **Example**: `TheGridInTest.SaveGridAsJpg("/path/to/output.jpg", quality: 85);`

#### `SaveGridAsBmp(string filePath)`
Saves the grid visual as a BMP file.
- **Parameters**:
  - `filePath`: The file path where to save the BMP
- **Returns**: `bool` - True if successful, false otherwise
- **Example**: `TheGridInTest.SaveGridAsBmp("/path/to/output.bmp");`

#### `CopyGridToClipboardAsync()`
Captures the grid visual as a PNG and copies it to the clipboard (cross-platform).
- **Returns**: `Task<bool>` - True if successful, false otherwise
- **Example**: `bool success = await TheGridInTest.CopyGridToClipboardAsync();`
- **Note**: This is an async method and must be awaited

## Development

The GridTestBed project serves as a development and testing environment for the LAWgrid control. It includes multiple test buttons for different functionality testing scenarios.

## Platform Support

As an Avalonia-based control, LAWgrid supports:
- Windows
- Linux
- macOS

## License

MIT

## Author

Lonnie Watson
