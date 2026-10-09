# Genomix

Genomix is a desktop proof of concept for a local bioinformatics research workspace. This repository currently contains the Avalonia application shell and basic Overview/Samples navigation. Upload, analysis, storage, and reporting workflows are not implemented yet.

## Set up and run

### Requirements

- Windows
- .NET 10 SDK
- Internet access for the first restore, so NuGet can download the project dependencies

Check that the SDK is installed:

```powershell
dotnet --list-sdks
```

From the repository root, restore and start the app:

```powershell
dotnet restore
dotnet run
```

Alternatively, run the project directly:

```powershell
dotnet run --project .\Genomix.csproj
```

The app opens a desktop window. Select **Samples** to open its current placeholder page; select **Back to overview** to return. Close the window to stop the app.

If `dotnet run` reports that `Genomix.exe` is being used by another process, close any other Genomix window or process and run the command again.

## Current structure

- `Program.cs` configures and starts Avalonia's desktop lifetime.
- `App.axaml` and `App.axaml.cs` load application resources and initialize the frontend and backend.
- `Frontend/Frontend.cs` creates the main window and routes navigation requests through `INavigation`.
- `Frontend/INavigation.cs` defines the available scene names and navigation contract.
- `MainWindow.axaml` defines the current window layout.
- `MainWindow.axaml.cs` handles the Overview/Samples view events and display.
- `Backend/Backend.cs` is a placeholder for application services and state.
- `Styles/` contains shared button and text styles.

## Sprint 1 progress

This section is the running Sprint 1 checklist. Add new work as a dated entry and update the status when it changes.

- [x] App startup creates and displays the main window.
- [x] Basic Overview and Samples navigation works through the frontend navigation pattern.
- [ ] Prerequisite 1: create wireframes for all planned pages.
- [ ] Prerequisite 2: create and review the backend ER diagram.
- [ ] Prerequisite 3: define the deployment topology and installation outline.
- [ ] Document the agreed shell layout and navigation in the wireframes.

## Known limitations

Keep this list current as Sprint 1 and later work progresses. Remove an item only when the capability is implemented and verified.

| ID | Limitation | Current impact |
| --- | --- | --- |
| L1 | The Samples page is a placeholder. | No file picker, upload, sample metadata, or paired-read labeling is available. |
| L2 | File validation and ingestion are not implemented. | FASTQ/FASTA files are not inspected, validated, or stored. |
| L3 | Bioinformatics tools are not integrated. | FASTQC, MultiQC, FASTP, and PRIMM cannot be run. |
| L4 | Backend services and persistent storage are not implemented. | There is no database, user/sample/run persistence, or ER-backed data model. |
| L5 | Authentication and authorization are not implemented. | The app does not restrict access to authorized PGC staff. |
| L6 | Results, reports, and audit logging are not implemented. | No metrics dashboard, PDF/CSV/HTML export, or activity history is available. |
| L7 | Deployment packaging and server setup are not documented. | This is currently run as a development desktop app; standalone server deployment is future work. |
| L8 | Only the Windows development setup is documented. | Other operating systems and deployment environments have not been verified. |

## Dependencies

The project uses Avalonia `12.1.2`, Fluent theme `12.1.2`, and the Inter font package `12.1.2`. NuGet restores these dependencies using the project file (`Genomix.csproj`).
